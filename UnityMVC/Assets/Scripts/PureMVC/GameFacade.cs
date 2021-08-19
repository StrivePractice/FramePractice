using PureMVC.Interfaces;
using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : Facade
{
    //1.继承PureMVC中的Facade脚本

    //2.为了方便我们使用Facade 需要自己写一个单例模式的属性

    public static GameFacade Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Facade();
            }
            return instance as GameFacade;
        }
    }

    /// <summary>
    /// 3.初始化控制层相关的内容
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();
        //这里要写一些关于命令和通知 绑定的逻辑
        RegisterCommand(PureNotification.START_UP, () =>
        {

            return new StartUpCommand();
        });
    }

    //4.一定有一个启动函数
    public void StartUp()
    {
        //发送通知
        SendNotification(PureNotification.START_UP);
    }
}
