using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Upgrades : ScriptableObject
{
    public List<Upgrade> upgrades = new List<Upgrade>();

    [System.Serializable]
    public class Upgrade
    {
        public string name, description;
        public Sprite icon;
        public UpgradeType upgradeType;
        public float statAmount;
        public enum UpgradeType
        {
            bulletDamage,
            bulletSpeed,
            fíreRate,
            barrel
        }
    }
}
