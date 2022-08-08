using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 输入管理器
/// </summary>
public class YLInputManager : YLSingleton<YLInputManager>,IBaseManager
{
    public void Initialize()
    {
    }
    /// <summary>
    /// 获取鼠标抬起
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool GetMouseUp(int value)
    {
        return Input.GetMouseButtonUp(value);
    }
    /// <summary>
    /// 获取鼠标
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool GetMouse(int value)
    {
        return Input.GetMouseButton(value);
    }
    /// <summary>
    /// 获取鼠标按下
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool GetMouseDown(int value)
    {
       return Input.GetMouseButtonDown(value);
    }
    /// <summary>
    /// 获取按键
    /// </summary>
    /// <param name="keyCode"></param>
    /// <returns></returns>
    public bool GetKey(KeyCode keyCode)
    {
        return Input.GetKey(keyCode);
    }
    /// <summary>
    /// 获取按键抬起
    /// </summary>
    /// <param name="keyCode"></param>
    /// <returns></returns>
    public bool GetKeyUp(KeyCode keyCode)
    {
        return Input.GetKeyUp(keyCode);
    }
    /// <summary>
    /// 获取按键按下
    /// </summary>
    /// <param name="keyCode"></param>
    /// <returns></returns>
    public bool GetKeyDown(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }
    public void Deinitialize()
    {
    }

}
