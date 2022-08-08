using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : YLBasePanel
{
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine("OpenSeletPanel");
        
    }
    /// <summary>
    /// 加载结束进入选择界面
    /// </summary>
    /// <returns></returns>
    IEnumerator OpenSeletPanel()
    {
        yield return new WaitForSeconds(2.0f);
        YLScenesManager.Instance.LoadScene(SceneType.Select);
        YLSingleton<Start>.Instance.DeInitialize();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
