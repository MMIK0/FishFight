using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public ButtonEvent OnButtonPress;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void ActivateButton(int buttonId)
    {
        OnButtonPress.Invoke(buttonId);
    }

    public void ActivateNextBarrel(int barrelId)
    {
        Player.instance.upgradeMenu.ActivateNextBarrel(barrelId);
    }

    public void OpenUpgradeMenu()
    {
        Player.instance.upgradeMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseUpgradeMenu()
    {
        Player.instance.upgradeMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
[System.Serializable]
public class ButtonEvent : UnityEvent<int> { }
