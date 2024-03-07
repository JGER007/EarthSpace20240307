using System.Collections;
using System.Collections.Generic;
using com.frame;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XRSpaceFacade : Facade
{
    protected override void initManagers ()
    {
        base.initManagers ();
        //MsgManager.ShowMsgContent ("测试测试测试测试");
        //EventUtil.DispatchEvent (GlobalEvent.Open_Module, "example");
        SceneManager.LoadScene ("ARSpaceScene", LoadSceneMode.Single);
    }
}
