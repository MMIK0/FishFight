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
    bool iniSpawn =false;
    public bool debugLines = false;
    float currentIntesity;
    private Dictionary<GameObject,float> enemies = new Dictionary<GameObject, float>();

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        bool iniSpawn = false;
    }

    private void Start()
    {
        if (currentIntesity < spawnList.currentSpawnlist.waveIntensity)
            RandomSpawn();
        iniSpawn = true;
    }
    private void Update()
    {
        if(!iniSpawn)
            return;
        if (currentIntesity < spawnList.currentSpawnlist.waveIntensity)
            SurroundSpawn();
        elapsedTime += Time.deltaTime;
        if(debugLines)
            DrawLines();
    }
    public void EnemyDead(GameObject g)
    {
        if (enemies.ContainsKey(g))
        {
            currentIntesity -= enemies[g];
            enemies.Remove(g);
        }
    }

    private void DrawLines()
    {
        Vector3 spawnDirFromPlayer = Vector3.zero;
        foreach (GameObject gg in enemies.Keys)
        {
            spawnDirFromPlayer += (Camera.main.WorldToScreenPoint(gg.transform.position) - Camera.main.WorldToScreenPoint(Player.instance.transform.position)).normalized;
            Debug.DrawLine(Camera.main.WorldToScreenPoint(gg.transform.position), Camera.main.WorldToScreenPoint(Player.instance.transform.position), Color.blue);
        }
        Debug.DrawRay(Camera.main.WorldToScreenPoint(Player.instance.transform.position), -spawnDirFromPlayer*1000, Color.red);

    }

    public void SurroundSpawn()
    {
        float h = Screen.height;
        float w = Screen.width;
        Vector3 SpiceOfRandom = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        Vector3 spawnDirFromPlayer = Vector3.zero;
        Vector3 a = Camera.main.WorldToScreenPoint(Player.instance.transform.position);
        foreach (GameObject gg in enemies.Keys)
            spawnDirFromPlayer += (Camera.main.WorldToScreenPoint(gg.transform.position) - a).normalized;

        Vector3 temp = -spawnDirFromPlayer.normalized;

        temp += SpiceOfRandom;
        Vector3 spawnCords=Vector3.zero;
        if(Mathf.Abs(temp.x)>= Mathf.Abs(temp.y))
        {
            if (temp.x > 0)
                spawnCords.x = w;
            else
                spawnCords.x = 0;
            if (temp.y > 0)
            {
                spawnCords.y = (h - a.y) * (Mathf.Abs(temp.y) / Mathf.Abs(temp.x)) + a.y;
            }
            else
            {
                spawnCords.y = a.y -a.y * (Mathf.Abs(temp.y) / Mathf.Abs(temp.x));
            }
        }
        else
        {
            if (temp.y > 0)
                spawnCords.y = h;
            else
                spawnCords.y = 0;
            if (temp.x > 0)
            {
                spawnCords.x = (w - a.x) * (Mathf.Abs(temp.x) / Mathf.Abs(temp.y)) + a.x;
            }
            else
            {
                spawnCords.x = a.x - a.x * (Mathf.Abs(temp.x) / Mathf.Abs(temp.y));
            }
        }
        spawnDirFromPlayer.z = 0;
        if(spawnDirFromPlayer== Vector3.zero)
        {
            RandomSpawn();
            return;
        }
        spawnList.SetCurrentSpawn(spawnList.GetSpawnList(elapsedTime));
        Vector3 spawnpoint = Camera.main.ScreenToWorldPoint(spawnCords);
        var g = spawnList.GetWeightedSpawn(spawnList.currentSpawnlist.waveIntensity - currentIntesity);
        var u = Instantiate(g.thingToSpawn, spawnpoint, Quaternion.identity);
        enemies.Add(u,g.weight);
        currentIntesity += g.weight;
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
        var g = spawnList.GetRandomSpawn();
        var u = Instantiate(g.thingToSpawn, spawnpoint, Quaternion.identity);
        enemies.Add(u, g.weight);
        currentIntesity += g.weight;
    }

}
