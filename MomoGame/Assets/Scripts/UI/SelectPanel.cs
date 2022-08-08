using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : YLBasePanel
{
    private Button btn_Start;
    private Transform content;
    private Button btn_Friend;
    private Button btn_Setting;
    private Button btn_Send;

    private Button btn_Quit;
    private Button btn_Sound;
    private Button btn_Chat;
    private Button btn_Weibo;

    private GameObject setting;
    private GameObject send;


    private Text text_Level;

    private int currentLevel;
    private Toggle[] toggles;
    private List<Image> images;

    private Image lockImage1;
    private Image lockImage2;
    private Image lockImage3;
    private Image lockImage4;
    private Image lockImage5;



    private void Awake()
    {
        toggles=new Toggle[5];
        images = new List<Image>();
        YLEventManager.Instance.Regist("ss", SetCurrentLevel);
        btn_Setting = transform.Find("ButtonSetting").GetComponent<Button>();
        btn_Friend = transform.Find("ButtonFriend").GetComponent<Button>();
        btn_Send = transform.Find("ButtonSend").GetComponent<Button>();
        btn_Start = transform.Find("BtnStart").GetComponent<Button>();

        setting = transform.Find("Setting").gameObject;
        send = transform.Find("Send").gameObject;

        btn_Quit = transform.Find("Setting/ButtonQuit").GetComponent<Button>();
        btn_Sound = transform.Find("Setting/ButtonSound").GetComponent<Button>();
        btn_Chat = transform.Find("Send/ButtonChat").GetComponent<Button>();
        btn_Weibo = transform.Find("Send/ButtonWeibo").GetComponent<Button>();

        text_Level = transform.Find("Text").GetComponent<Text>();
        content = transform.Find("ScrollView/Viewport/Content");
        Debug.Log(content.ToString()) ;
        lockImage1 = content.transform.Find("Toggle0/Image").GetComponent<Image>();
        lockImage2 = content.transform.Find("Toggle1/Image").GetComponent<Image>();
        lockImage3 = content.transform.Find("Toggle2/Image").GetComponent<Image>();
        lockImage4 = content.transform.Find("Toggle3/Image").GetComponent<Image>();
        lockImage5 = content.transform.Find("Toggle4/Image").GetComponent<Image>();
        images.Add(lockImage1);
        images.Add(lockImage2);
        images.Add(lockImage3);
        images.Add(lockImage4);
        images.Add(lockImage5);
        toggles = content.GetComponentsInChildren<Toggle>();


    }
    private void OnDestroy()
    {
        YLEventManager.Instance.UnRegist("ss", SetCurrentLevel);
    }
    /// <summary>
    /// 设置当前选择关卡
    /// </summary>
    /// <param name="objs"></param>
    private void SetCurrentLevel(object[] objs)
    {
        Debug.Log((int)objs[0]);
        currentLevel = (int)objs[0];
        GameManager.Instance.currentLevel = currentLevel;
    }
    /// <summary>
    /// 设置显示关卡
    /// </summary>
    /// <param name="value"></param>
    public void SetLevel(int value)
    {
        text_Level.text = value.ToString();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        btn_Start.onClick.AddListener(StartBtn);
        btn_Setting.onClick.AddListener(SettingBtn);
        btn_Send.onClick.AddListener(SendBtn);
        btn_Friend.onClick.AddListener(FriendBtn);

        btn_Sound.onClick.AddListener(SoundBtn);
        btn_Quit.onClick.AddListener(QuitBtn);
        btn_Chat.onClick.AddListener(ChatBtn);
        btn_Weibo.onClick.AddListener(WeiboBtn);
        setting.SetActive(false);
        send.SetActive(false);
        User user= YLDataManager.Instance.GetUser("momo");
        SetLevel(user.Level);
        SetToggleEnable(user.Level);
        SetLockEnable(user.Level);
    }
    /// <summary>
    /// 微博
    /// </summary>
    private void WeiboBtn()
    {
        send.SetActive(false);
    }
    /// <summary>
    /// 微信
    /// </summary>
    private void ChatBtn()
    {
        send.SetActive(false);
    }
    /// <summary>
    /// 退出游戏
    /// </summary>
    private void QuitBtn()
    {
        setting.SetActive(false);
        Application.Quit();
    }
    /// <summary>
    /// 打开声音面板
    /// </summary>
    private void SoundBtn()
    {
        setting.SetActive(false);
        YLUIManager.Instance.OpenPanel<SoundPanel>();
    }
    /// <summary>
    /// 设置关卡可点击
    /// </summary>
    /// <param name="value"></param>
    public void SetToggleEnable(int value)
    {
        foreach (var item in toggles)
        {
            item.interactable = false;
        }
        for (int i = 0; i < value; i++)
        {
            toggles[i].interactable = true;
        }
    }
    /// <summary>
    /// 设置关卡解锁
    /// </summary>
    /// <param name="value"></param>
    public void SetLockEnable(int value)
    {
        foreach (var item in images)
        {
            item.gameObject.SetActive(true);
        }
        for (int i = 0; i < value; i++)
        {
            images[i].gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// 分享
    /// </summary>
    private void SendBtn()
    {
        send.SetActive(true);
    }
    /// <summary>
    /// 打开朋友面板
    /// </summary>
    private void FriendBtn()
    {
        YLUIManager.Instance.OpenPanel<FriendPanel>();
    }
    /// <summary>
    /// 设置面板
    /// </summary>
    private void SettingBtn()
    {
        setting.SetActive(true);
    }
    /// <summary>
    /// 开始游戏
    /// </summary>
    private void StartBtn()
    {
        YLScenesManager.Instance.LoadScene(SceneType.Game);
        YLSingleton<Select>.Instance.DeInitialize();
        GameManager.Instance.currentLevel = currentLevel;
    }
}
