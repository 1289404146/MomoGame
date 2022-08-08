using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendPanel : YLBasePanel
{
    private Button button_Friend;
    private Image image_Friend1;
    private Image image_Friend2;
    private Image image_Friend3;
    private Image image_Friend4;
    private Image image_Friend5;
    private List<Image> images;
    private void Awake()
    {
        button_Friend=transform.Find("ButtonBack").GetComponent<Button>();
        image_Friend1=transform.Find("ImageF1/Image").GetComponent<Image>();
        image_Friend2 = transform.Find("ImageF2/Image").GetComponent<Image>();
        image_Friend3 = transform.Find("ImageF3/Image").GetComponent<Image>();
        image_Friend4 = transform.Find("ImageF4/Image").GetComponent<Image>();
        image_Friend5 = transform.Find("ImageF5/Image").GetComponent<Image>();
        images=new List<Image>();
        images.Add(image_Friend1);
        images.Add(image_Friend2);
        images.Add(image_Friend3);
        images.Add(image_Friend4);
        images.Add(image_Friend5);
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        button_Friend.onClick.AddListener(BackBtn);
        User user= YLDataManager.Instance.GetUser("momo");
        Debug.Log(user.Friend);
        SetFriend(user.Friend);
    }
    /// <summary>
    ///关闭朋友界面
    /// </summary>
    private void BackBtn()
    {
        YLUIManager.Instance.ClosePanel<FriendPanel>();
    }
    /// <summary>
    /// 设置朋友解锁
    /// </summary>
    /// <param name="value"></param>
    public void SetFriend(int value)
    {
        for (int i = 0; i < value; i++)
        {
            images[i].gameObject.SetActive(false);
        }
    }
 
}
