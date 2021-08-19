using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoleViewMediator : Mediator
{
    public static new string NAME = "NewRoleViewMediator";
    //1.继承pureMVC中的Mediator脚本
    //2.写构造函数
    public NewRoleViewMediator() : base(NAME)
    {

    }


    //3.重写监听通知的方法

    public override string[] ListNotificationInterests()
    {
        //这是一个pureMVC的规则
        //就是你需要监听哪些通知，那就在这里把通知们通过字符串数组的形式返回出去
        //PureMVC就会帮助我们监听这些通知
        return new string[] {
            PureNotification.UPDATE_PLAYER_INFO,
        };
    }

    //4.重写处理通知的方法

    public override void HandleNotification(INotification notification)
    {
        //INotification 里面包含两个重要的参数
        //1.通知名 根据这个名字来做对应的处理
        //2.通知包含的信息
        switch (notification.Name)
        {
            case PureNotification.UPDATE_PLAYER_INFO:
                ( ViewComponent as NewRoleView ).UpdateInfo(( notification.Body as PlayerDataObj ));
                break;
        }
    }
}
