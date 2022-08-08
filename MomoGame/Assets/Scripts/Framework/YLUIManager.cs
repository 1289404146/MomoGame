using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLUIManager : YLUnitySingleton<YLUIManager>,IBaseManager
{
    /// <summary>
    /// 挂载面板的Canvas
    /// </summary>
    private Transform canvas;
    /// <summary>
    /// 保存所有打开的页面
    /// </summary>
    private Dictionary<string, YLBasePanel> panelDict;

    private void Awake()
    {
        canvas = transform.Find("Canvas");
    }

    /// <summary>
    /// 初始化UIManager
    /// </summary>
    public void Initialize()
    {
        panelDict = new Dictionary<string, YLBasePanel>();
    }


    /// <summary>
    /// 打开面板
    /// </summary>
    /// <typeparam name="T">面板的类型</typeparam>
    /// <returns></returns>
    public T OpenPanel<T>() where T:YLBasePanel
    {
        string panelName = typeof(T).Name;
        if(panelDict.ContainsKey(panelName))
        {
            return panelDict[panelName] as T;
        }
        GameObject panelPrefab = YLResourcesManager.Instance.Load<GameObject>("UI/" + panelName);
        //克隆游戏对象
        //添加游戏脚本
        T panel = GameObject.Instantiate(panelPrefab).AddComponent<T>();
        //一定不要省略
        panel.name = panelName;
        panel.transform.SetParent(canvas);
        panel.transform.localPosition = Vector3.zero;
        panel.transform.localRotation = Quaternion.identity;
        panel.transform.localScale = Vector3.one;
        panelDict.Add(panelName, panel);
        return panel;

    }

    /// <summary>
    /// 获取面板
    /// </summary>
    /// <typeparam name="T">面板的类型</typeparam>
    /// <returns></returns>
    public T GetPanel<T>() where T:YLBasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDict.ContainsKey(panelName))
        {
            return panelDict[panelName] as T;
        }
        return null;
    }
    /// <summary>
    /// 关闭面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void ClosePanel<T>() where T:YLBasePanel
    {
        string panelName = typeof(T).Name;
        if(panelDict.ContainsKey(panelName))
        {
            //销毁场景中的游戏对象
            Destroy(panelDict[panelName].gameObject);
            //销毁内存中的游戏对象
            panelDict.Remove(panelName);
        }
    }
    /// <summary>
    /// 销毁所有的面板
    /// </summary>
    public void CloseAll()
    {
        foreach (var item in panelDict)
        {
            Destroy(panelDict[item.Key].gameObject);
        }
        panelDict.Clear();
    }
    /// <summary>
    /// 结束UIManager
    /// </summary>
    public void Deinitialize()
    {
        panelDict.Clear();
    }

}
