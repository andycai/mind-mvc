namespace Mind.MVC.API
{
    public interface IController : INotifier
    {
        string Name { get; set; }
        IView View { get; set; }
        IHandler[] ListNotification();
        void OnRegister();
        void OnRemove();
    }
}