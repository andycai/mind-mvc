using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Mind.MVC.API;

namespace Mind.MVC.Impl
{
    /// <summary>
    /// 外观模式
    /// MVC 管理者
    /// </summary>
    public class Facade : IFacade
    {
        protected static IFacade instance;
        protected readonly ConcurrentDictionary<string, IList<IObserver>> observerMap;

        public Facade()
        {
            if (instance != null) throw new Exception("Facade Singleton already constructed.");

            observerMap = new ConcurrentDictionary<string, IList<IObserver>>(); 
        }

        public static IFacade GetInstance()
        {
            if (instance == null)
            {
                instance = new Facade();
            }
            return instance;
        }

        public void SendNotification(string name, object body = null, string type = null)
        {
            NotifyObservers(new Notification(name, body, type));
        }

        public void RegisterObserver(IController controller)
        {
            IHandler[] handlers = controller.ListNotification();
            foreach (IHandler handler in handlers)
            {
                string name = handler.Name;

                if (name == "" || name == null)
                {
                    throw new Exception("Name of notification should not be empty.");
                }

                if (observerMap.TryGetValue(name, out IList<IObserver> observers))
                {
                    observers.Add(new Observer(handler.HandleFunc, controller));
                }
                else
                {
                    observerMap.TryAdd(name, new List<IObserver> { new Observer(handler.HandleFunc, controller) });
                }
            }
            controller.OnRegister();
        }

        public void RemoveObserver(string notificationName, object notifyContext)
        {
            if (observerMap.TryGetValue(notificationName, out IList<IObserver> observers))
            {
                for (int i = 0; i < observers.Count; i++)
                {
                    if (observers[i].CompareNotifyContext(notifyContext))
                    {
                        observers.RemoveAt(i);
                        break;
                    }
                }

                if (observers.Count == 0)
                {
                    observerMap.TryRemove(notificationName, out IList<IObserver> _);
                }
            }
        }

        public void RegisterObservers(IController[] controllers)
        {
            foreach (IController controller in controllers)
            {
                RegisterObserver(controller);
            }
        }

        public void NotifyObservers(INotification notification)
        {
            if (observerMap.TryGetValue(notification.Name, out IList<IObserver> observers_ref))
            {
                // 使用副本，因为引用的数组有可能会循环过程中改变
                var observers = new List<IObserver>(observers_ref);
                foreach (IObserver observer in observers)
                {
                    observer.NotifyObserver(notification);
                }
            }
        }
    }
}