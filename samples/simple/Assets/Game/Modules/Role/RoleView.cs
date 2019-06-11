using Mind.MVC.Impl;
using Mind.Utils;

public class RoleView: BaseView
{
    public RoleView()
    {
    }

    public static RoleView Self()
    {
        return Singleton<RoleView>.GetInstance();
    }
}
