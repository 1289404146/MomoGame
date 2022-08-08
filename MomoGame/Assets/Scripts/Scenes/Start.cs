using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : BaseScene, IScene
{
    /// <summary>
    /// 初始化
    /// </summary>
    public void Initialize()
    {
        YLUIManager.Instance.OpenPanel<StartPanel>();
    }
    /// <summary>
    /// TODO 跳转场景的时候需要调用方法
    /// </summary>
    public void DeInitialize()
    {
        YLUIManager.Instance.CloseAll();
    }

    
}
