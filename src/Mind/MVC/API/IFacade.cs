namespace Mind.MVC.API
{
    public interface IFacade : INotifier
    {
        void RegisterObserver(IController controller);
        void RegisterObservers(IController[] controllers);
        void NotifyObservers(INotification notification);
    }
}