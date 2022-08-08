using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : YLBaseMono
{

    /// <summary>
    /// 进入触发器
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.Instance.HP += 1;
            YLUIManager.Instance.GetPanel<GamePanel>().SetTextHp(GameManager.Instance.HP);
        }
    }
}
