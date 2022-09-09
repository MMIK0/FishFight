using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public Upgrades.Upgrade upgrade;
    public int barrelId;
    public TextMeshProUGUI upgradeName, upgradeDesc;

    public void OnEnable()
    {
        //defaults barrelId to 0
        barrelId = 0;
        GetUpgrade();
        upgradeName.text = upgrade.name;
        upgradeDesc.text = upgrade.description;
    }

    public void SelectUIUpgrade()
    {
        if(upgrade.upgradeType == Upgrades.Upgrade.UpgradeType.barrel)
        {
            UpgradeManager.instance.ActivateBarrel();
        }
        else if (upgrade.upgradeType == Upgrades.Upgrade.UpgradeType.fíreRate)
        {
            UpgradeManager.instance.IncreaseFireRate(barrelId);
        }
        else if (upgrade.upgradeType == Upgrades.Upgrade.UpgradeType.bulletDamage)
        {
            UpgradeManager.instance.IncreaseDamage(barrelId);
        }
        /*else if (upgrade.upgradeType == Upgrades.Upgrade.UpgradeType.bulletSpeed)
        {
            UpgradeManager.instance.IncreaseFlyingSpeed(barrelId);
        }*/
        UiManager.instance.CloseUpgradeMenu();
    }

    public void GetUpgrade()
    {
        upgrade = UpgradeManager.instance.GetNewUpgrade();
    }
}
