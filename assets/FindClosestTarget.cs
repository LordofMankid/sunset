using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestTarget : MonoBehaviour
{

    
    public GameObject FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        GameObject targetEnemy = null;
        foreach (GameObject currentEnemy in enemyManager.enemies)
        {
            Debug.Log(enemyManager.enemies.Count);
            float distance = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distance < closestDistance)
            {
                closestDistance = distance;
                targetEnemy = currentEnemy;
                
            }
        }

        return targetEnemy;
    }
    // Update is called once per frame
}
