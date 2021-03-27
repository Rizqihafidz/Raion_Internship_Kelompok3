using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6f;
    [SerializeField]
    private float _rubahX = 0f;
    [SerializeField]
    private float _rubahY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.gameObject.CompareTag("Ladder"))
            {
            if (collision.tag == "Player" && Input.GetKey(KeyCode.W))
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _speed);
            }
            else if (collision.tag == "Player" && Input.GetKey(KeyCode.S))
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -_speed);
            }
            else
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(_rubahX, _rubahY);
            }
        }
        
    }
}
