using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private GameObject target;

    private Rigidbody2D body;
    public Vector2 directionToPlayer {get; private set; }

    //private Transform target;
    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>(); // body is whatever it's attached to
        target = GameObject.FindGameObjectWithTag("Player"); // find the player
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = target.transform.position - transform.position; // find the vector in between target and the curren position
        directionToPlayer = enemyToPlayerVector.normalized; // find just the angle (remember that normalizing a vector turns it into a unit vector :> )
        
        CharacterData data = GetComponent<CharacterControl>().data;
        body.velocity = directionToPlayer * data.speed;  // moves towards player's direction
    }



}
