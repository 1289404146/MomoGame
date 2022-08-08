using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : YLBasePanel
{
    private Button button_Continue;
    private Button button_Back;
    private Button button_ReStart;

    private void Awake()
    {
        button_Continue = transform.Find("ButtonContinue").GetComponent<Button>();
        button_Back = transform.Find("ButtonBack").GetComponent<Button>();
        button_ReStart = transform.Find("ButtonRestart").GetComponent<Button>();
        Time.timeScale = 0;
    }
    // Start is called before the first frame update
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
    protected override void Start()
    {
        button_Continue.onClick.AddListener(ContinueBtn);
        button_Back.onClick.AddListener(BackBtn);
        button_ReStart.onClick.AddListener(ReStartBtn);
    }
    /// <summary>
    /// 继续游戏
    /// </summary>
    private void ContinueBtn()
    {
        YLUIManager.Instance.ClosePanel<PausePanel>();
    }
    /// <summary>
    /// 重新开始
    /// </summary>
    private void ReStartBtn()
    {
        YLSingleton<Game>.Instance.DeInitialize();
        YLScenesManager.Instance.LoadScene(SceneType.Game);
    }
    /// <summary>
    /// 回到选择界面
    /// </summary>
    private void BackBtn()
    {
        YLScenesManager.Instance.LoadScene(SceneType.Select);
        YLSingleton<Game>.Instance.DeInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
