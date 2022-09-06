using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public List<Barrel> barrels = new List<Barrel>();
    public Upgrades upgradeList;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public Upgrades.Upgrade GetNewUpgrade()
    {
        Upgrades.Upgrade upgrade = upgradeList.GetRandomUpgrade();
        Debug.Log(upgrade);
        return upgrade;
    }

    public void ActivateBarrel()
    {
        foreach(Barrel barrel in barrels)
        {
            if (barrel.isActiveAndEnabled)
                continue;
            else
            {
                barrel.gameObject.SetActive(true);
                break;
            }
        }
    }

}
