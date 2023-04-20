using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed = 1.5f;

    [SerializeField] private Kunai KunaiPrefab;
    [SerializeField] private Transform throwPoint;

    [SerializeField] private GameObject attackArea;


    internal void SavePoint()
    {
        savePoint = transform.position;
        //throw new NotImplementedException();
    }

    [SerializeField] private float jumpForce = 420;
    private bool isGrounded = false;
    private bool isJumping = false;
    private bool isAttack = false;
    private bool isDeath = false;

    private float horizontal;

    private int coin = 0;
    private Vector3 savePoint;



    private void Awake()
    {
        coin = PlayerPrefs.GetInt("coin",0);

    }
    // Update is called once per frame
    void Update()
    {
        if (IsDeath)
        {
            return;

        }
        isGrounded = CheckGrounded();
        //-1..0..1 
        //horizontal = Input.GetAxisRaw("Horizontal");


        if (isAttack)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (isGrounded)
        {
            if (isJumping)
            {
                return;
            }
            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }

            //change anim run
            if (Mathf.Abs(horizontal) > 0.1f)
            {
                ChangeAnim("run");
            }
            //attack
            if (Input.GetKeyDown(KeyCode.C) && isGrounded)
            {
                Attack();
            }


            //throw
            if (Input.GetKeyDown(KeyCode.X) && isGrounded)
            {
                Throw();
            }
        }
        //check fall
        if (!isGrounded && rb.velocity.y < 0)
        {
            ChangeAnim("fall");
            isJumping = false;
        }
        //Moving
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            //moving left and right
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            //transform.localScale = new Vector3(horizontal, 1, 1); ko nen scale =-1

            //cau truc tat : horizontal>0?0:180 : neu horizontal >0 ->> =0 else  = 180
            //Di chuyen sang trai quay nhan vat 180*
            transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));
        }
        //change anim idle when isGrounded is true
        else if (isGrounded)
        {
            ChangeAnim("idle");
            rb.velocity = Vector2.zero;
        }


    }

    public override void OnInit()
    {
        base.OnInit();
        isDeath = false;
        isAttack = false;
        transform.position = savePoint;
        ChangeAnim("idle");
        DeActiveAttack();
        SavePoint();

        UIManager.instance.SetCoin(coin);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        OnInit();
    }
    protected override void OnDeath()
    {
        base.OnDeath();
    }

    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);
        return hit.collider != null;

    }

    public void Attack()
    {
        isAttack = true;
        ChangeAnim("attack");
        Invoke(nameof(ResetAttack), 0.5f);
        ActiveAttack();
        Invoke(nameof(DeActiveAttack),0.5f);
    }
    public void Throw()
    {
        isAttack = true;
        ChangeAnim("throw");
        Invoke(nameof(ResetAttack), 0.5f);

        Instantiate(KunaiPrefab,throwPoint.position,throwPoint.rotation);
    }
    private void ResetAttack()
    {
        isAttack = false;
        ChangeAnim("idle");
    }
    public void Jump()
    {
        isJumping = true;
        rb.AddForce(jumpForce * Vector2.up);
        ChangeAnim("jump");
    }

    private void ActiveAttack() {
        attackArea.SetActive(true);
    
    }

    private void DeActiveAttack() {
        attackArea.SetActive(false);
    }
    public void SetMove(float horizontal)
    {
        this.horizontal = horizontal;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin") {
            coin++;
            PlayerPrefs.SetInt("coin", coin);
            UIManager.instance.SetCoin(coin);
            Destroy(collision.gameObject);
            //Debug.Log("Coin"+ collision.gameObject.name);
        }
        if (collision.tag == "deathZone")
        {
            ChangeAnim("die");
            //Destroy(collision.gameObject);
            isDeath = true;
            //Debug.Log("Coin" + collision.gameObject.name);\
            Invoke(nameof(OnInit),0.5f);
        }
    }
}
