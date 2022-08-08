using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : BaseScene,IScene
{
    /// <summary>
    /// 初始胡
    /// </summary>
    public void Initialize()
    {
        YLUIManager.Instance.OpenPanel<SelectPanel>();
    }
    /// <summary>
    /// 结束初始化
    /// </summary>
    public void DeInitialize()
    {
        YLUIManager.Instance.CloseAll();
    }

}
