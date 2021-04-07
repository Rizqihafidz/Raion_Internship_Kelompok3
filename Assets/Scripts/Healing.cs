using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{

    [SerializeField]
    private PlayerMovement _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_player.getLives() != 3)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _player.Heal();
                Destroy(this.gameObject);
            }
        }

            

    }
}
