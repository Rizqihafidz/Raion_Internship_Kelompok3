using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    [SerializeField]
    private PlayerMovement _player;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < -9.2f)
        {
            transform.position = new Vector3(7.2f, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.Damage();
            Destroy(this.gameObject);
        }
    }

}

