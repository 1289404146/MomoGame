using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLAudioSourceManager : YLUnitySingleton<YLAudioSourceManager>,IBaseManager
{
    /// <summary>
    /// 背景音乐
    /// </summary>
    private AudioSource bgmAudioSourcee;
    private void Awake()
    {
        bgmAudioSourcee = GetComponent<AudioSource>();
    }
    public void Initialize()
    {
        bgmAudioSourcee.volume = 0.1f;
        bgmAudioSourcee.mute = false;
    }
    /// <summary>
    /// 设置背景音乐的大小
    /// </summary>
    /// <param name="volume"></param>
    public void SetBgVolume(float volume)
    {
        bgmAudioSourcee.volume = volume;
    }
    /// <summary>
    /// 获取背景音乐大小
    /// </summary>
    /// <returns></returns>
    public float GetBGMVolume()
    {
        return bgmAudioSourcee.volume;
    }
    public void Deinitialize()
    {
    }
}
