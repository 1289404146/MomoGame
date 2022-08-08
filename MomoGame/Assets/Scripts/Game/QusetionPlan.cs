using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QusetionPlan : YLBaseMono
{
    public GameObject friend;
    void Start()
    {
        friend.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            friend.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
