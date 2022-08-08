using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 规范场景行为的接口
/// </summary>
public interface IScene
{
    /// <summary>
    /// 初始化场景
    /// </summary>
    void Initialize();
    /// <summary>
    /// 结束场景
    /// </summary>
    void DeInitialize();
}
