using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 场景的类型
/// 要和Scenes in Build 中顺序保持一致
/// </summary>
public enum SceneType
{
    Laucher = 0,
    Start,
    Select,
    Game
}

public class YLScenesManager : YLUnitySingleton<YLScenesManager>,IBaseManager
{
    /// <summary>
    /// Initialize  方法执行在 Awake之后 Start方法执行之前
    /// </summary>
    public void Initialize()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    /// <summary>
    /// 监听场景是否切换
    /// </summary>
    /// <param name="arg0">场景</param>
    /// <param name="arg1">场景加载的模式</param>
    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        SceneType index = (SceneType)scene.buildIndex;
        switch (index)
        {
            case SceneType.Laucher:
                break;
            case SceneType.Start:
                YLSingleton<Start>.Instance.Initialize();
                break;
            case SceneType.Select:
                YLSingleton<Select>.Instance.Initialize();
                break;
            case SceneType.Game:
                YLSingleton<Game>.Instance.Initialize();
                break;
            default:
                break;
        }
    }

    public void LoadScene(SceneType sceneType)
    {
        SceneManager.LoadScene((int)sceneType);
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deinitialize()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }
}
