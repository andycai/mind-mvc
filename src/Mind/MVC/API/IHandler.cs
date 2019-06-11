using System;

namespace Mind.MVC.API
{
    public interface IHandler
    {
        string Name { get; set; } 
        Action<INotification> HandleFunc { get; set; } 
    }
}