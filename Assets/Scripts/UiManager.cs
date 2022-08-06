using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void OpenUpgradeMenu()
    {
        Player.instance.upgradeMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseUpgradeMenu()
    {
        Player.instance.upgradeMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
