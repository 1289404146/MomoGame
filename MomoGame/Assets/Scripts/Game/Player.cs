using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家动画状态
/// </summary>
public class PlayerAnimState
{
    public const string AnimState = "Anim";
    public const int Idel = 0;
    public const int Move = 1;
    public const int jump = 2;
    public const int Attack = 3;
};
public class Player : YLBaseMono
{
    /// <summary>
    /// 跳跃次数
    /// </summary>
    private int m_jumpCount = 0;


    private Animator m_ani;
    private Rigidbody2D m_rig;
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// 一段跳速度
    /// </summary>
    public float JumpSpeed = 20;
    /// <summary>
    /// 二段跳速度
    /// </summary>
    public float SecondJumpSpeed = 15;

    private void Awake()
    {
        YLEventManager.Instance.Regist(YLEventDefine.EVENT_JUMP, OnEventJump);
    }

    private void OnDestroy()
    {
        YLEventManager.Instance.UnRegist(YLEventDefine.EVENT_JUMP, OnEventJump);
    }

    void Start()
    {
        m_ani = gameObject.GetComponent<Animator>();
        m_rig = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer= gameObject.GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 跳起
    /// </summary>
    /// <param name="args"></param>
    void OnEventJump(params object[] args)
    {
        if (0 == m_jumpCount)   //一段
        {
            m_ani.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.jump);
            m_rig.velocity = new Vector2(0, JumpSpeed);
            ++m_jumpCount;
        }
        else if (1 == m_jumpCount)  //二段
        {
            //m_ani.SetBool("IsJumping2", true);
            m_rig.velocity = new Vector2(0, SecondJumpSpeed);
            ++m_jumpCount;
        }
    }

    void Update()
    {
        if (GameState.Playing != GameManager.Instance.state) return;
        if (YLInputManager.Instance.GetKey(KeyCode.A))
        {
            m_ani.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.Move);
            transform.position -= new Vector3(10,0) * Time.deltaTime;
            spriteRenderer.flipX= true;
            //m_rig.AddForce(new Vector2(-1000,0)*Time.deltaTime);
        }
        else if (YLInputManager.Instance.GetKey(KeyCode.D))
        {
            m_ani.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.Move);
            transform.position += new Vector3(10, 0) * Time.deltaTime;
            spriteRenderer.flipX= false;
            //m_rig.AddForce(new Vector2(1000,0)*Time.deltaTime);
        }
        // 按下空白键
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnEventJump();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            m_ani.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.Idel);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            m_ani.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.Idel);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_ani.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.Idel);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (spriteRenderer.flipX)
            {
                ShootBullet(Vector3.left);
            }
            else
            {
                ShootBullet(Vector3.right);
            }
            m_ani.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.Attack);
        }
        if (Input.GetMouseButtonUp(0))
        {
            m_ani.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.Idel);
        }
    }
    void ShootBullet(Vector3 vector)
    {
        GameObject obj= YLResourcesManager.Instance.Load<GameObject>("Game/PlayerBullet");
        GameObject insObj= GameObject.Instantiate(obj,transform.position,Quaternion.identity);
        Rigidbody2D rig=insObj.GetComponent<Rigidbody2D>();
        rig.velocity = transform.TransformDirection(vector * 20);
        Destroy(insObj,1.0f);
    }
    /// <summary>
    /// 碰撞事件方法
    /// </summary>
    /// <param name="other"></param>
	void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                {
                    // 碰撞到地面
                    //m_ani.SetBool("IsJumping1", false);
                    //m_ani.SetBool("IsJumping2", false);

                    m_jumpCount = 0;
                }
                break;
            case "Border":
                {
                    // 游戏结束
                    GameManager.Instance.state = GameState.End;
                }
                break;
        }

    }

}
