using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireProjectile : MonoBehaviour
{
    [SerializeField]
    private float fireRate = 2.0f;

    public Transform firePoint;
    public GameObject projectile;
    //private EnemyControl controller; // need for the direction
    private GameObject target;

    // Update is called once per frame
    void Awake()
    {
        // set target based on who it is; probably import from scriptable object later
        

        // set target based on tag, later turn this to "hero" and "ally?" not sure how to 
        if(gameObject.tag == "Player")
        {
            Debug.Log("hi");
            //InvokeRepeating("playerFire", 2.0f, fireRate);

        } else
        {
            target = GameObject.FindGameObjectWithTag("Player"); // find the player;
            InvokeRepeating("fire", 2.0f, fireRate);

        }
        //controller = GetComponent<EnemyControl>();
        
    }


    // might be able to turn this into one of those virtual override things once u learn the syntax haha
    void fire()
    {
        // casts projectile as game object so i can modify it 
        GameObject projectileInstance = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject; 

        // initialize projectile's velocity to target's direction (I want the projectile to be able to do this in the projectile's own thing so FIX LATER) 
        projectileInstance.GetComponent<projectileControl>().setVariables(target, gameObject.GetComponent<CharacterControl>().data); // set bullet to fire at player
    }

    public void playerFire()
    {
        target = GetComponent<FindClosestTarget>().FindClosestEnemy();
        if(target != null)
        {
            GameObject projectileInstance = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;
            projectileInstance.GetComponent<projectileControl>().setVariables(target, gameObject.GetComponent<CharacterControl>().data); // set bullet to fire at player
    
        }
        // initialize projectile's velocity to target's direction (I want the projectile to be able to do this in the projectile's own thing so FIX LATER) 
    }
}
