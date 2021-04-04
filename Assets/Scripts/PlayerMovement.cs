using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private float ladderSpeed = 20f;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask whatIsLadder;
    [SerializeField] private bool isClimbing;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;

    [SerializeField] int _lives = 3;
    private UIManagerUwU _uiManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _uiManager = GameObject.Find("Canvas2").GetComponent<UIManagerUwU>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

       
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        
    }

    public void Damage()
    {
        _lives--;

        _uiManager.UpdateLives(_lives);

        if (_lives < 1)
        {
            Destroy(this.gameObject);
            //gameMaster.restart();
        }
    }
}
