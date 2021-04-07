using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    [SerializeField]
    private PlayerMovement _player;
    public bool _moveRight = true;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        

        if (_moveRight)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.Damage();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Turn"))
        {
            if (_moveRight) {
                _moveRight = false;
            }else
                {
                 _moveRight = true;
                }
            }
        
    }

}

