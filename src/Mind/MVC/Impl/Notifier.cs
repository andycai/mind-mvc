using Mind.MVC.API;

namespace Mind.MVC.Impl
{
    /// <summary>
    /// 消息发送器，所有需要有发送消息能力的都可以继承此类
    /// </summary>
    public class Notifier: INotifier
    {
        public void SendNotification(string name, object body = null, string type = null)
        {
            Facade.GetInstance().SendNotification(name, body, type);
        }
    }
}