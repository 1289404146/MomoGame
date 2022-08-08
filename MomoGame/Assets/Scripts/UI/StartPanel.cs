using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : YLBasePanel
{
    private Button btn_Start;

    // Start is called before the first frame update
    private void Awake()
    {
        btn_Start = transform.Find("BtnStart").GetComponent<Button>();
    }
    protected override void Start()
    {
        base.Start();
        btn_Start.onClick.AddListener(StartBtn);
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    private void StartBtn()
    {
        YLUIManager.Instance.OpenPanel<LoadingPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
