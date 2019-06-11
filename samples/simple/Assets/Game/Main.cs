using Mind.MVC.API;
using Mind.MVC.Impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Facade.GetInstance().RegisterObservers(new IController[] {
            new RoleController(),
        });
        Facade.GetInstance().SendNotification(RoleEvent.EVENT_GAME_START);
        Facade.GetInstance().SendNotification(RoleEvent.EVENT_ROLE_SHOW_INFO);
        Debug.Log("==============main start() => start game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
