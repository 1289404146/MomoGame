using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : YLBasePanel
{
    private Button btn_Restart;
    private Button btn_Back;

    private Text text_Coin;
    private void Awake()
    {
        btn_Restart = transform.Find("ButtonRestart").GetComponent<Button>();
        btn_Back = transform.Find("ButtonBack").GetComponent<Button>();
        text_Coin = transform.Find("Text").GetComponent<Text>();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        btn_Restart.onClick.AddListener(RestartBtn);
        btn_Back.onClick.AddListener(BackBtn);
    }
    /// <summary>
    /// 下一关
    /// </summary>
    private void BackBtn()
    {
        if (GameManager.Instance.currentLevel >= 4)
        {
            YLScenesManager.Instance.LoadScene(SceneType.Select);
            YLSingleton<Game>.Instance.DeInitialize();
        }
        else
        {
            YLSingleton<Game>.Instance.DeInitialize();
            GameManager.Instance.currentLevel += 1;
            YLScenesManager.Instance.LoadScene(SceneType.Game);
        }

    }
    /// <summary>
    /// 设置金币
    /// </summary>
    /// <param name="coin"></param>
    public void SetText(float coin)
    {
        text_Coin.text = coin.ToString();
    }
    /// <summary>
    /// 重新开始
    /// </summary>
    private void RestartBtn()
    {
        YLScenesManager.Instance.LoadScene(SceneType.Select);
        YLSingleton<Game>.Instance.DeInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
