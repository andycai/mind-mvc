using Mind.MVC.API;
using System;

namespace Mind.MVC.Impl
{
    /// <summary>
    /// 控制层，提供消息的转发处理，具体的逻辑会转到M, V, S层
    /// </summary>
    public class Controller : Notifier, IController
    {
        public string Name { get; set; }
        public IView View { get; set; }

        public Controller()
        {
            //Name = name;
        }

        protected IHandler NewHandler(string name, Action<INotification> func)
        {
            return new Handler(name, func);
        }

        public virtual IHandler[] ListNotification()
        {
            return new IHandler[0];
        }

        public virtual void OnRegister()
        {
            //
        }

        public virtual void OnRemove()
        {
            //
        }
    }
}