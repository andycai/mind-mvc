using Mind.MVC.API;

namespace Mind.MVC.Impl
{
    /// <summary>
    /// 消息的数据结构
    /// </summary>
    public class Notification : INotification
    {
        public string Name { get; set; }
        public object Body { get; set; }
        public string Type { get; set; }
        public Notification(string name, object body = null, string type = null)
        {
            Name = name;
            Body = body;
            Type = type;
        }
    }
}