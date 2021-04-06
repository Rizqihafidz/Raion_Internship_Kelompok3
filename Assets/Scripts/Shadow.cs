using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private int current;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        pos.y = -0.69f;
        rb.MovePosition(pos);
        //if (transform.position != target.position)
        //{
        //    Vector2 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //    rb.MovePosition(pos);
        //} else
        //{
            
        //}
    }
}
