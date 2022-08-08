using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPanel : YLBasePanel
{
    private Slider slider_Sound;
    private Button button_Sound;

    private void Awake()
    {
        button_Sound = transform.Find("ButtonBack").GetComponent<Button>();
        slider_Sound = transform.Find("Slider").GetComponent<Slider>();
    }
    protected override void Start()
    {
        base.Start();
        slider_Sound.value = YLAudioSourceManager.Instance.GetBGMVolume();
        slider_Sound.onValueChanged.AddListener(SoundChange);
        button_Sound.onClick.AddListener(BackBtn);
    }
    /// <summary>
    /// 关闭声音设置
    /// </summary>
    private void BackBtn()
    {
        YLUIManager.Instance.ClosePanel<SoundPanel>();
    }
    /// <summary>
    /// 改变声音大小
    /// </summary>
    /// <param name="value"></param>
    private void SoundChange(float value)
    {
        YLAudioSourceManager.Instance.SetBgVolume(value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
