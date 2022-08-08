using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : YLBasePanel
{
    private Button btn_Restart;
    private Button btn_Back;

    private Text text_Lose;
    private void Awake()
    {
        btn_Restart = transform.Find("ButtonRestart").GetComponent<Button>();
        btn_Back = transform.Find("ButtonBack").GetComponent<Button>();
        text_Lose = transform.Find("Text").GetComponent<Text>();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        btn_Restart.onClick.AddListener(RestartBtn);
        btn_Back.onClick.AddListener(BackBtn);
    }
    /// <summary>
    /// 回到选择界面
    /// </summary>
    private void BackBtn()
    {
        YLScenesManager.Instance.LoadScene(SceneType.Select);
        YLSingleton<Game>.Instance.DeInitialize();
    }
    /// <summary>
    /// 设置金币
    /// </summary>
    /// <param name="coin"></param>
    public void SetText(float coin)
    {
        text_Lose.text = coin.ToString();
    }
    /// <summary>
    /// 重新开始
    /// </summary>
    private void RestartBtn()
    {
        YLSingleton<Game>.Instance.DeInitialize();
        YLScenesManager.Instance.LoadScene(SceneType.Game);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
