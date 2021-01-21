using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Debug Variables")] public bool isAlive;
    public bool hasJumped;
    public bool hasAttacked;

    [Header("Rigidbody")] public Rigidbody2D rb;

    [Header("Box Collider")] public BoxCollider2D attackBox;

    [Header("Animator")] public Animator anim;


    [Header("Player Properties")] public float jumpForce;


    private PlayerControls _playerControls;

    public GameObject testBoar;


    #region Touch Properties

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    #endregion


    #region Start

    void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            CreateControls();
        }
    }

    private void CreateControls()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
        _playerControls.Player.Jump.performed += context => { Jump(); };
        _playerControls.Player.Attack.performed += context => { Attack(); };
        Debug.Log("Created Controls");
    }

    #endregion

    /// <summary>
    /// This region will handle all touch gestures, possibly keyboard with the new input system,
    /// </summary>

    #region Gestures

    void TrackGestures()
    {
        if (isAlive)
        {
            //Touch
            if (Input.touchCount > 0)
            {
                #region Gesture Tracking

                var touch = Input.GetTouch(0);

                //Tracking TouchPhases, and finger positions
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startTouchPosition = Input.GetTouch(0).position;
                }

                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    endTouchPosition = Input.GetTouch(0).position;
                }

                //--------------------

                #endregion

                if (touch.position.x < Screen.width / 2)
                {
                    if (endTouchPosition.y > startTouchPosition.y)
                    {
                        Jump();
                    }
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    Attack();
                }
            }
        }
    }

    #endregion


    void Attack()
    {
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
            TrackGestures();
        else
        {
            HandleInput();
        }

        if (hasJumped && rb.velocity.y <= 0.1)
        {
            hasJumped = false;
            //anim.SetTrigger("run");
        }
    }

    void HandleInput()
    {
        //Handle Keyboard inputs
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
    }

    void Jump()
    {
        // if (!hasJumped)
        // {
        //     if (rb.velocity.y == 0)
        //     {
        //         rb.AddForce(Vector2.up * jumpForce);
        //         hasJumped = true;
        //         //anim.SetTrigger("jump");
        //     }
        // }
    }
}