using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    
    /// <summary>
    ///  turn this into the dictionary of enemy types? dunno this is just for testing so doens't matter as much
    /// </summary>
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float interval = 10.0f;

    private GameObject hero; 

    public static List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        hero = GameObject.FindGameObjectWithTag("Player"); // find the player
        enemies.Add(GameObject.FindGameObjectWithTag("Enemy")); // add initial enemy; can get rid of later
        
        StartCoroutine(spawnEnemy(interval, enemyPrefab));
    }


    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        Vector2 heroPos = hero.transform.position;

        GameObject newEnemy = Instantiate(enemy, new Vector2(Random.Range(heroPos.x - 5, heroPos.x + 5), Random.Range(heroPos.y - 5, heroPos.y + 5)), Quaternion.identity);
        enemies.Add(newEnemy);
        
        
        StartCoroutine(spawnEnemy(interval, enemy));

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
