namespace Mind.MVC.API
{
    public interface INotifier
    {
        void SendNotification(string name, object body = null, string type = null);
    }
}