using Mind.MVC.API;
using System;

namespace Mind.MVC.Impl
{
    /// <summary>
    /// 控制层，提供消息的转发处理，具体的逻辑会转到M, V, S层
    /// </summary>
    public class Controller : Notifier, IController
    {
		protected IHandler NewHandler(string name, Action<INotification> func)
        {
            return new Handler(name, func);
        }

		/// <summary>
		/// 返回订阅的消息数组
		/// </summary>
        public virtual IHandler[] ListNotification()
        {
            return new IHandler[0];
        }

		/// <summary>
		/// 控制器实例化后调用的方法，只调用一次
		/// </summary>
        public virtual void OnRegister()
        {
            //
        }
    }
}