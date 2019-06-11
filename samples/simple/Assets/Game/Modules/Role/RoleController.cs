using Mind.MVC.API;
using Mind.MVC.Impl;
using UnityEngine;

public class RoleController : BaseController 
{
    public RoleController()
    {
        Name = "RoleController";
    }

    public override IHandler[] ListNotification()
    {
        return new IHandler[] {
            NewHandler(RoleEvent.EVENT_GAME_START, handleStartGame),
            NewHandler(RoleEvent.EVENT_ROLE_SHOW_INFO, handleShowInfo),
         };
    }

    public void handleStartGame(INotification notification)
    {
        Debug.Log("============== start game");
        Debug.LogWarning("============== start game");
        Debug.LogError("============= start game");
    }

    public void handleShowInfo(INotification notification)
    {
        Debug.Log("============== show role info");
    }
}
