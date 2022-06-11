using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public List<GameObject> enemyToSpawn;
    public List<GameObject> pool;
    public Vector2 enemySpawnPoint;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        PoolEnemy();
        foreach(GameObject obj in pool)
        {
            GameObject enemy = Instantiate(obj);
            enemy.transform.parent = this.transform;
            enemy.SetActive(true);
            enemy.transform.position = enemySpawnPoint;
        }
    }

    public void Update()
    {
        if (pool.Count < 1)
            PoolEnemy();
    }

    public void PoolEnemy()
    {
        foreach (GameObject enemy in enemyToSpawn)
        {
            GameObject enemyToAdd;
            enemyToAdd = enemyToSpawn[Random.Range(1, enemyToSpawn.Count)];
            enemy.SetActive(false);
            pool.Add(enemyToAdd);
        }
    }
}
