using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : YLBaseMono
{
    private SpriteRenderer spriteRenderer;
    private Vector3 right;
    private Vector3 left;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(5, 10);
        right = transform.position + new Vector3(x,0,0);
        left = transform.position ;

        spriteRenderer = GetComponent<SpriteRenderer>();
        //transform.position += new Vector3(5, 0);

    }
    private bool moveRight=false;
    private float speed=5;
    private bool ison=false;
    // Update is called once per frame
    void Update()
    {
        if (moveRight == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, right, Time.deltaTime * speed);
            spriteRenderer.flipX = false;
            if (ison)
            {
                ShootBullet(Vector3.right);
                ison = false;
            }
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, left,Time.deltaTime*speed);
            spriteRenderer.flipX = true;
            if (ison)
            {
                ShootBullet(Vector3.left);
                ison = false;
            }
        }
        if (transform.position.x == right.x && moveRight == false)
        {
            moveRight = true;
            ison = true;
        }
        else if (transform.position.x == left.x && moveRight == true)
        { 
            moveRight=false;
            ison = true;
        }
    }
    void ShootBullet(Vector3 vector)
    {
        GameObject obj = YLResourcesManager.Instance.Load<GameObject>("Game/EnemyBullet");
        GameObject insObj = GameObject.Instantiate(obj, transform.position, Quaternion.identity);
        Rigidbody2D rig = insObj.GetComponent<Rigidbody2D>();
        rig.velocity = transform.TransformDirection(vector * 20);
        Destroy(insObj, 0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
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
