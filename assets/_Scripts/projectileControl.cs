using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileControl : MonoBehaviour
{

    // TODO: convert these fields to data ScriptableObject
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private int damage; 

    [SerializeField]
    private float range = 10f;

    private Vector2 startLocation;
    
    private Rigidbody2D projectile;

    private GameObject target; // passed in when called, I feel like this should be in some sort of constructor?

    // Start is called before the first frame update

    public void setTarget(GameObject objectToFireAt)
    {
        target = objectToFireAt;

    }
    // selects target based on target type
    void Start ()
    {
        projectile = GetComponent<Rigidbody2D>();
        startLocation = projectile.position;


        // TODO (eventually) make target selection a variable that you can set for ally units and yourself (fire on closest target, highest health, etc)
        // also figure out a way that doesn't involve an O(n) every time you fucking fire [maybe overhead isn't that bad with < 1000 targets]
            Vector2 targetVector = (Vector2)target.transform.position - projectile.position; // find the vector in between target and the curren position
            projectile.velocity = targetVector.normalized * speed;  // moves towards player's direction
        } 
        


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.gameObject == target ) // probably switch away from tags idk might be fine haha
        {
            //Debug.Log(hitInfo.name + " takes damage");
            CharacterControl character = hitInfo.GetComponent<CharacterControl>();

            if(character != null)
            {
                character.TakeDamage(damage);
            }
            Destroy(gameObject); // disappear once hit

        }
    }

    private void Update()
    {
        if(Vector2.Distance(projectile.position, startLocation) > range)
        {
            Destroy(gameObject);
        } 
    }
    // Update is called once per frame

}
