using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Upgrades : ScriptableObject
{
    public List<Upgrade> upgrades = new List<Upgrade>();

    public Upgrade GetRandomUpgrade()
    {
        Upgrade upgrade = upgrades[Random.Range(0, upgrades.Count)];

        return upgrade;
    }

    public Upgrade GetRandomUpgrade(Upgrade.UpgradeType u)
    {
        Upgrade upgrade = upgrades[Random.Range(0, upgrades.Count)];

        return upgrade;
    }

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
