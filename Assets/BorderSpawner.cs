using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderSpawner : MonoBehaviour
{
    public static BorderSpawner Instance;
    public SpawnList spawnList;
    public int targetEnemyAmount;
    private int currentEnemyAmount;
    private float elapsedTime=0;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (currentEnemyAmount < targetEnemyAmount)
            RandomSpawn();
        elapsedTime += Time.deltaTime;
    }
    public void EnemyDead()
    {
        currentEnemyAmount -= 1;
    }
    public void RandomSpawn()
    {
        float h = Screen.height;
        float w = Screen.width;
        float a = Random.Range(1, 3);
        a = 2 / a - a;
        float b = Random.Range(1, 3);
        b = 2 / b - b;
        float c = Random.Range(1, 3);
        c = 2 / c - c;

        if (a > 0)
            a = a + w;
        if (b > 0)
            b = b + h;
        Vector3 spawnpoint = Vector3.zero;
        if (c>0)
            spawnpoint = Camera.main.ScreenToWorldPoint(new Vector3(a, Random.Range(0.01f, 1) * h, 0));
        else
            spawnpoint = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0.01f, 1) * w,b, 0));
        spawnList.SetCurrentSpawn(spawnList.GetSpawnList(elapsedTime));
        Instantiate(spawnList.GetRandomSpawn(),spawnpoint,Quaternion.identity);
        currentEnemyAmount += 1;
    }

}
