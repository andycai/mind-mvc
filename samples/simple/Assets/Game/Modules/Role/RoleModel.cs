using Mind.MVC.Impl;
using Mind.Utils;

public class RoleEvent
{
    public static string EVENT_GAME_START = "EVENT_GAME_START";
    public static string EVENT_ROLE_SHOW_INFO = "EVENT_ROLE_SHOW_INFO";
}

public class RoleModel : BaseModel 
{
    public RoleModel()
    {
    }

    // 使用单体模式
    public static RoleModel Self()
    {
        return Singleton<RoleModel>.GetInstance();
    }
}
