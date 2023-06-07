using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : CharacterControl
{

    //public CharacterData data; // scriptable object, stores all data set somewhere else
    public HealthBar healthBar;
    //public int currentHealth { get; private set; } // allows other objects to get, but only this object to modify current health
    

    // Start is called before the first frame update
    void Start()
    {
        if (data != null)
        {
            Awake();
        }
    }

    void Awake()
    {
        currentHealth = data.health; // set current health 
        healthBar.SetMaxHealth(data.health);
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log(data.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public new virtual void Die()
    {
        Destroy(gameObject);
        Debug.Log(data.name + "died");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
