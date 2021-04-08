using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius;
    private bool isGrounded;

    private Animator animator;

    private PlayerMovement player;

    void OnTrigger2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            player.Damage();            
        }
    }

    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Shadow").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(isGrounded)
        {
            animator.SetTrigger("run");
        }
    }
}
