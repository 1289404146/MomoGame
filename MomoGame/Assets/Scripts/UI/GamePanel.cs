using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : YLBasePanel
{
    private Button button_Quit;
    private RawImage image_Msg;
    private Text text_Msg;
    private Text text_Coin;
    private Text text_Hp;
    private List<string> msgList;

    /// <summary>
    /// 打字间隔
    /// </summary>
    public float typeTimer = 0.1f;
    /// <summary>
    /// 当前文字
    /// </summary>
    public string words;
    private bool isStartTyping = false;//是否开始打字
    private float timer;
    private int currentIndex = 0;
    private void Awake()
    {
        msgList=new List<string>();
        button_Quit =transform.Find("ButtonQuit").GetComponent<Button>();
        image_Msg = transform.Find("ImageMsg").GetComponent<RawImage>();
        text_Msg = transform.Find("ImageMsg/TextMsg").GetComponent<Text>();
        text_Coin =transform.Find("TextCoin").GetComponent<Text>();
        text_Hp=transform.Find("TextHp").GetComponent<Text>();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //返回两个或多个值中最大的值
        typeTimer = Mathf.Max(0.02f, typeTimer);
        image_Msg.gameObject.SetActive(false);
        button_Quit.onClick.AddListener(BackBtn);
        msgList.Add("城市：嘿！你是momo吧。久仰大名啦~知道你很厉害但是前面的路很危险，不过美丽的景色也值得你冒险前进~");
        msgList.Add("太空：呀！太空来了新朋友，我是喵儿，负责太空的生态，我们一起打败菌怪魔王团吧~");
        msgList.Add("沙漠：汪汪，我是柴宝！沙漠很热吧~喝口水休息一会，世界还等着我们拯救呢！");
        msgList.Add("海底：你好呀~很高兴认识你，我叫团团。第一次来深海世界吧，小心菌怪魔王团哦！");
        msgList.Add("雨林：你好呀~很高兴认识你，我叫小瓜。欢迎来到雨林，让我们一起打败菌怪魔王团吧！");
        SetTextCoin(GameManager.Instance.Coin);
        SetTextHp(GameManager.Instance.HP);
    }
    /// <summary>
    /// 设置弹窗图片
    /// </summary>
    /// <param name="texture"></param>
    public void SetImage(Texture texture)
    {
        image_Msg.texture = texture;
        image_Msg.gameObject.SetActive(true);
    }
    /// <summary>
    /// 继续游戏
    /// </summary>
    private void BackBtn()
    {
        YLUIManager.Instance.OpenPanel<PausePanel>();
    }
    /// <summary>
    /// 设置显示文字
    /// </summary>
    /// <param name="value"></param>
    public void SetImage(int value)
    {
        words=msgList[value];
        isStartTyping = true;
    }
    public IEnumerator SetImagefalse()
    {
        yield return new WaitForSeconds(2);

        image_Msg.gameObject.SetActive(false);
    }
    /// <summary>
    /// 设置Hp
    /// </summary>
    /// <param name="value"></param>
    public void SetTextHp(float value)
    {
        if (value <= 0)
        {
            text_Hp.text = "0";
        }
        text_Hp.text = value.ToString();
    }
    /// <summary>
    /// 设置金币
    /// </summary>
    /// <param name="value"></param>
    public void SetTextCoin(float value)
    {
        text_Coin.text = value.ToString();
    }

    private void Update()
    {
        OnStartTyping();
    }
    /// <summary>
    /// 开始打字机效果
    /// </summary>
    private void OnStartTyping()
    {
        if (isStartTyping)
        {
            timer += Time.deltaTime;
            if (timer >= typeTimer)
            {
                timer = 0;
                currentIndex++;
                text_Msg.text = words.Substring(0, currentIndex);
                if (currentIndex >= words.Length)
                {
                    isStartTyping = false;
                    timer = 0;
                    currentIndex = 0;
                    words = "";
                    StartCoroutine("SetImagefalse");
                }
            }
        }
    }
}
