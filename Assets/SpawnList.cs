using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpawnList : ScriptableObject
{
    public List<TimeBasedSpawn> spawns;
    public TimeBasedSpawn currentSpawnlist =new TimeBasedSpawn();
    
    [System.Serializable]
    public class TimeBasedSpawn
    {
        public float spawnTime;
        public List<GameObject> thingsToSpawn = new List<GameObject>();
    }
    public void SetCurrentSpawn(TimeBasedSpawn s)
    {
        currentSpawnlist = s;
    }
    public GameObject GetRandomSpawn()
    {
        return currentSpawnlist.thingsToSpawn[Random.Range(0, currentSpawnlist.thingsToSpawn.Count)];
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
