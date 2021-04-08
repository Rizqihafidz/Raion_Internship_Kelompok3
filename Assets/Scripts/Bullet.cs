using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemi minion = hitInfo.GetComponent<Enemi>();
        if(minion != null)
        {
            minion.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
