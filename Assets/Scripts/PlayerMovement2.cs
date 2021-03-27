using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float MovementSpeed = 1;
    public float JumpForce = 1;

    public float ladderSpeed = 20f;
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;

    
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        animator.SetFloat("Speed", Mathf.Abs(movement));

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, whatIsLadder);

        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
            else
            {
                isClimbing = false;
            }
        }
        if (isClimbing == true)
        {
            var verticalMove = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.position.x, verticalMove * ladderSpeed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 3;
        }
    }
}
