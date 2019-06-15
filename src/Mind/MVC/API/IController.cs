namespace Mind.MVC.API
{
    public interface IController : INotifier
    {
        IHandler[] ListNotification();
        void OnRegister();
        void OnRemove();
    }
}