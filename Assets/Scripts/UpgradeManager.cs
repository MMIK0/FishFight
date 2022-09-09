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
            {
                Debug.Log("We continued");
                continue;
            }
            else
            {
                Debug.Log("upgrademanager " + " " + barrel.id);
                barrel.gameObject.SetActive(true);
                UiManager.instance.ActivateNextBarrel(barrel.id);
                break;
            }
        }
    }
    public void IncreaseFireRate(int barrelId)
    {
        for(int i = 0; i < barrels.Count; i++)
        {
            if(barrels[i].id == barrelId)
            {
                barrels[i].bullet.fireRate -= 0.05f;
                Debug.Log(barrels[i].bullet.fireRate);
            }
        }
    }
    public void IncreaseDamage(int barrelId)
    {
        for (int i = 0; i < barrels.Count; i++)
        {
            if (barrels[i].id == barrelId)
            {
                barrels[i].damage += 1;
                Debug.Log(barrels[i].damage);
            }
        }
    }

    /// <summary>
    /// DOES NOT COMPUTE D:
    /// </summary>
    /// <param name="barrelId"></param>

    public void IncreaseFlyingSpeed(int barrelId)
    {
        for (int i = 0; i < barrels.Count; i++)
        {
            if (barrels[i].id == barrelId)
            {
                barrels[i].bullet.speed += 0.5f;
                Debug.Log(barrels[i].damage);
            }
        }
    }
}
