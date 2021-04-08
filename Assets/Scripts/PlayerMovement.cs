using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameMaster gm;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;

    [SerializeField] int _lives = 3;
    private UIManagerUwU _uiManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _uiManager = GameObject.Find("Canvas2").GetComponent<UIManagerUwU>();
        gm = GetComponent<GameMaster>();
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

    public int getLives()
    {
        return _lives;
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

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Heal()
    {
        if (_lives == 3)
        {
            _lives = _lives;
        }
        else
        {
            _lives += 1;
        }

        _uiManager.UpdateLives(_lives);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }
}
