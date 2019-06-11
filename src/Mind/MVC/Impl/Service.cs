using Mind.MVC.API;

namespace Mind.MVC.Impl
{
    /// <summary>
    /// 1. 通用接口层，提供给其他模块使用
    /// 2. 与服务器交互接口
    /// </summary>
    public class Service : Notifier, IService
    {
    }
}