using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : YLBaseMono
{

    /// <summary>
    /// 进入触发器
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            YLUIManager.Instance.OpenPanel<WinPanel>().SetText(GameManager.Instance.Coin);
            if (GameManager.Instance.currentLevel+1 == YLDataManager.Instance.GetUser("momo").Level)
            {
                if (GameManager.Instance.currentLevel + 1<5)
                {
                    YLDataManager.Instance.GetUser("momo").Level += 1;
                }
            }
            GameManager.Instance.state = GameState.End;
        }
    }
}
