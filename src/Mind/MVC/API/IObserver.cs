using System;

namespace Mind.MVC.API
{
    public interface IObserver
    {
        Action<INotification> NotifyMethod { get; set; }
        object NotifyContext { get; set; }
        void NotifyObserver(INotification notification);
        bool CompareNotifyContext(object notifyContext);
    }
}