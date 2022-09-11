using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpawnList : ScriptableObject
{
    public List<TimeBasedSpawn> spawns;
    public TimeBasedSpawn currentSpawnlist = new TimeBasedSpawn();

    [System.Serializable]
    public class SpawnEnemy
    {
        public float weight;
        public GameObject thingToSpawn;
    }
    [System.Serializable]
    public class TimeBasedSpawn
    {
        public float spawnTime;
        public Dictionary<float, SpawnEnemy> weightDictionary ;
        public float waveIntensity =30;
        public List<SpawnEnemy> thingsToSpawn = new List<SpawnEnemy>();
    }
    public void SetCurrentSpawn(TimeBasedSpawn s)
    {
        s.weightDictionary = new Dictionary<float, SpawnEnemy>();
        foreach (SpawnEnemy l in s.thingsToSpawn)
        {
            Debug.Log(l.weight + " "+l.thingToSpawn);
            s.weightDictionary.Add(l.weight, l);
        }
        currentSpawnlist = s;
    }
    public SpawnEnemy GetRandomSpawn()
    {
        return currentSpawnlist.thingsToSpawn[Random.Range(0, currentSpawnlist.thingsToSpawn.Count)];
    }
    public SpawnEnemy GetWeightedSpawn(float availableWeight)
    {
        List<float> a = new List<float>();
        foreach (float key in currentSpawnlist.weightDictionary.Keys)
            if (key <= availableWeight)
                a.Add(key);
        if (a.Count == 0)
            return GetRandomSpawn();
        return currentSpawnlist.weightDictionary[a[Random.Range(0, a.Count)]];
    }
    public TimeBasedSpawn GetSpawnList(float time)
    {
        TimeBasedSpawn t=null;
        foreach(TimeBasedSpawn i in spawns)
        {
            if (t == null)
                t = i;
            else if (time >= i.spawnTime && Mathf.Abs(i.spawnTime - time) < Mathf.Abs(t.spawnTime - time))
                t = i;
        }
        return t;
    }
}
