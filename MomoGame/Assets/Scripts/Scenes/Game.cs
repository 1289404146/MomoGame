using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : BaseScene,IScene
{

    public void Initialize()
    {
        GameManager.Instance.Initialize();

    }
    /// <summary>
    /// TODO 跳转场景的时候需要调用方法
    /// </summary>
    public void DeInitialize()
    {
        YLUIManager.Instance.CloseAll();
        GameManager.Instance.Deinitialize();
    }

}
