using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : YLBaseMono
{
    public int coin=10;
    /// <summary>
    /// 进入触发器
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            Destroy(gameObject);
            GameManager.Instance.Coin += coin;
            YLUIManager.Instance.GetPanel<GamePanel>().SetTextCoin(GameManager.Instance.Coin);
        }
    }
    //private Transform coinRootTranform;

    ///// <summary>
    ///// 金币的结束位置
    ///// </summary>
    //private Transform end;


    ///// <summary>
    ///// 金币的移动速度
    ///// </summary>
    //private float moveSpeed = 0.05f;

    //void Awake()
    //{
    //    coinRootTranform = transform;

    //    end = GameObject.Find("GroundEndPos").transform;
    //}

    //public void SetPos(Vector3 startPos)
    //{
    //    float yPosOffset = 5 + Random.Range(3, 20) * 0.1f; //随机高度偏移
    //    coinRootTranform.position = startPos + new Vector3(0, yPosOffset, 0);
    //}

    //void Update()
    //{
    //    if (GameState.Playing != GameManager.Instance.state) return;

    //    if (coinRootTranform.position.x > end.position.x)
    //    {
    //        coinRootTranform.position -= new Vector3(moveSpeed, 0, 0);//往左移动
    //    }
    //    else
    //    {
    //        // 金币超过End坐标点，销毁
    //        Destroy(gameObject);
    //    }
    //}
}
