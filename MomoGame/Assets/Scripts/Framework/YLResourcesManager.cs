using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLResourcesManager : YLSingleton<YLResourcesManager>
{
    public T Load<T>(string name) where T : Object
    {
        T res = Resources.Load<T>(name);
        if (res == null)
        {
            return null;
        }
        return res;
    }
    public T Load<T>(string name, Vector3 position, Quaternion rotation) where T : Object
    {
        T res = Resources.Load<T>(name);
        if (res is GameObject)
            return Object.Instantiate(res, position, rotation);
        else
            return res;
    }
}
