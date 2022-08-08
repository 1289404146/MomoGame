using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLBasePanel : YLBaseMono
{
    protected RectTransform rectTransform;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        //第一个参数就是用于确定的基准边
        //第二个参数UI元素该边界与父物体的该边界的距离
        //第三个参数 设定选定轴上UI元素的大小
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 0);
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
        rectTransform.anchorMax = Vector2.one;
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.pivot = Vector2.one * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
