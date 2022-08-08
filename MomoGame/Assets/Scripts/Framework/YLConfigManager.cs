using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class YLConfigManager : YLSingleton<YLConfigManager>
{
    /// <summary>
    /// 加载数据出来
    /// </summary>
    /// <typeparam name="T">加载数据类型</typeparam>
    /// <param name="FilePath">相对于Assets文件夹的路径</param>
    /// <returns>加载出来的数据类</returns>
    public T LoadDataFrom<T>(string FilePath)
    {
        string t = Application.dataPath +"/Config/"+ FilePath;
        if (!File.Exists(t))
        {
            return default(T);
        }
        T obj = JsonUtility.FromJson<T>(File.ReadAllText(t));
        return obj;
    }

    /// <summary>
    /// 存储数据进去
    /// </summary>
    /// <typeparam name="T">存储数据类型</typeparam>
    /// <param name="Data">存储的数据变量</param>
    /// <param name="FilePath">相对于Assets文件夹的路径</param>
    public void SaveDataTo<T>(T Data, string FilePath)
    {
        string t = Application.dataPath +"/Config/"+ FilePath;
        if (!File.Exists(t))
        {
            File.Create(t).Dispose(); //dispose:释放占用
        }
        //File.AppendAllText(t, JsonUtility.ToJson(Data));
        File.WriteAllText(t, JsonUtility.ToJson(Data));
    }
}
