using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : YLBaseMono
{
    // Start is called before the first frame update
    void Start()
    {
        //在切换场景的时候不销毁游戏对象
        DontDestroyOnLoad(gameObject);
        YLUIManager.Instance.Initialize();
        YLScenesManager.Instance.Initialize();
        YLDataManager.Instance.Initialize();
        YLAudioSourceManager.Instance.Initialize();
        YLScenesManager.Instance.LoadScene(SceneType.Start);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        YLAudioSourceManager.Instance.Deinitialize();
        YLDataManager.Instance.Deinitialize();
        YLScenesManager.Instance.Deinitialize();
        YLUIManager.Instance.Deinitialize();
    }
}
