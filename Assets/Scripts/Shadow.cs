using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Shadow : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    public AIPath aiPath;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            player.Damage();            
        }
    }

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else if(aiPath.desiredVelocity.x <= -0.01)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
