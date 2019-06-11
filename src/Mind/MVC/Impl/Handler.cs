using Mind.MVC.API;
using System;

namespace Mind.MVC.Impl
{
    /// <summary>
    /// 处理器，消息处理数据封装
    /// </summary>
    public class Handler: IHandler
    {
        public string Name { get; set; }
        public Action<INotification> HandleFunc { get; set; }

        public Handler(string name, Action<INotification> func)
        {
            Name = name;
            HandleFunc = func;
        }
    }
}