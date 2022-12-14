using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 规范管理类的行为
/// </summary>
public interface IBaseManager
{
    /// <summary>
    /// 初始化方法
    /// </summary>
    void Initialize();
    /// <summary>
    /// 结束方法
    /// </summary>
    void Deinitialize();
}
