using Mind.MVC.Impl;
using Mind.Utils;

// 与服务器交互
// 提供通用的模块接口
public class RoleService: BaseService
{
    public RoleService()
    {
    }

    public static RoleService Self()
    {
        return Singleton<RoleService>.GetInstance();
    }

    // 请求服务器
    public void Request(object param)
    {
        //
    }
}
