using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class BulletHandler : ScriptableObject
{
    public List<BulletType> BulletList = new List<BulletType>();

    [System.Serializable]
    public class BulletType
    {
        public GameObject bulletPref;
    }

}