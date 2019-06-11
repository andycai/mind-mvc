using Mind.MVC.API;
using System;

namespace Mind.MVC.Impl
{
    /// <summary>
    /// 观察者模式中观察者
    /// </summary>
    public class Observer : IObserver
    {
        public Action<INotification> NotifyMethod { get; set; }
        public object NotifyContext { get; set; }

        public Observer(Action<INotification> notifyMethod, object notifyContext)
        {
            NotifyMethod = notifyMethod;
            NotifyContext = notifyContext;
        }

        public virtual void NotifyObserver(INotification notification)
        {
            NotifyMethod(notification);
        }

        public virtual bool CompareNotifyContext(object notifyContext)
        {
            return NotifyContext.Equals(notifyContext);
        }
    }
}