﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this);
            GameManager.Instance.HP -= 1;
            YLUIManager.Instance.GetPanel<GamePanel>().SetTextHp(GameManager.Instance.HP);
            if (GameManager.Instance.HP <= 0)
            {
                YLUIManager.Instance.OpenPanel<LosePanel>().SetText(GameManager.Instance.Coin);
                GameManager.Instance.state = GameState.End;
            }
        }
    }
}
