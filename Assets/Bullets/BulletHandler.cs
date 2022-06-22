using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class BulletHandler : ScriptableObject
{
    public Dictionary<string, BulletType> BulletList = new Dictionary<string, BulletType>();

    [System.Serializable]
    public class BulletType
    {
        public GameObject bulletPref;
        public float fireRate;
    }

}