using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : YLBaseMono
{
    public int id;
    public bool islock;
    //public GameObject image;
    private Toggle toggle;
    private void Awake()
    {
        //image = transform.Find("Image").gameObject;
        toggle = GetComponent<Toggle>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (toggle.isOn == true)
        {
            YLEventManager.Instance.DispatchEvent("ss", id);
        }
        toggle.onValueChanged.AddListener((ison) =>
        {
            if (ison)
            {
                YLEventManager.Instance.DispatchEvent("ss", id);
            }
        }
        );
        //if (islock == false)
        //{
        //    toggle.interactable = true;
        //    image.SetActive(false);
        //}
        //else
        //{
        //    toggle.interactable = false;
        //    image.SetActive(true);
        //}
    }
    //public void SetImage(bool ison)
    //{
    //    image.SetActive(ison);
    //}
    //public void SetButtonClick(bool ison)
    //{
    //    toggle.interactable=ison;
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
