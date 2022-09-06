using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public Upgrades.Upgrade upgrade;

    public void OnEnable()
    {
        GetUpgrade();
    }

    public void CloseMenu()
    {
        Debug.Log("WAAAA");
        if(upgrade.upgradeType == Upgrades.Upgrade.UpgradeType.barrel)
        {
            UpgradeManager.instance.ActivateBarrel();
        }

        UiManager.instance.CloseUpgradeMenu();
    }

    public void GetUpgrade()
    {
        upgrade = UpgradeManager.instance.GetNewUpgrade();
    }
}
