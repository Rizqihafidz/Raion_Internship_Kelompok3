using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-9.2f, 9.2f), 6.5f,0);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down*_speed*Time.deltaTime);

        if(transform.position.y < -6.84f)
        {
            transform.position = new Vector3(Random.Range(-9.2f, 9.2f), 6.5f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(GameObject.FindWithTag("Laser"));
            Destroy(GameObject.FindWithTag("Enemy"));
        }
        
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            
            if(player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
        
       
    }

}

