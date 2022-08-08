using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class YLSingleton<T> where T:class,new()
{
    private readonly static object lockobj = new object();
    protected static T instance = null;
    /// <summary>
    /// 对象访问点
    /// </summary>
    public static T Instance
    {
        get
        {
            lock(lockobj)
            {
                if(instance == null)
                {
                    instance = new T();
                    return instance;
                }
                
            }
            return instance;
        }
    }
}
