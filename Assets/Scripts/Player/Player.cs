using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    [Header("Debug Variables")]
    public bool isAlive;
    public bool hasJumped;
    public bool hasAttacked;

    [Header("Rigidbody")]
    public Rigidbody2D rb;

    [Header("Box Collider")]
    public BoxCollider2D attackBox;

    [Header("Animator")]
    public Animator anim;


    [Header("Player Properties")] 
    public float jumpForce;
    
    #region Start
    void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        CreateControls();
    }

    private void CreateControls()
    {
        
    }

    #endregion
    

    void Attack()
    {
    }

    void Update()
    {
        if (hasJumped && rb.velocity.y <= 0.1)
        {
            hasJumped = false;
            //anim.SetTrigger("run");
        }

        if (isAlive)
        {

            //Touch
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    if (!hasJumped && touch.phase == TouchPhase.Began)
                        Jump();
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    Attack();
                }
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.2f);
        attackBox.enabled = false;
        yield return new WaitForSeconds(.5f);
        hasAttacked = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Obstacle")
        {
            isAlive = false;
            //GameManager.instance.OnDeath();
        }
    }
    
    void Jump()
    {
        if (!hasJumped)
        {
            if (rb.velocity.y == 0)
            {
                rb.AddForce(Vector2.up * jumpForce);
                hasJumped = true;
                //anim.SetTrigger("jump");
            }
        }
    }
}