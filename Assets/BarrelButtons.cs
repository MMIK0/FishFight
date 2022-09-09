using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrelButtons : MonoBehaviour
{
    public int barrelId;
    public List<GameObject> upgradeWindows = new List<GameObject>();
    public Button button;

    public void OnEnable()
    {
        UiManager.instance.OnButtonPress.AddListener(SetButtonPressed);
        button = GetComponent<Button>();

        if(barrelId == 0)
        {
            SetBarrelId();
            button.image.color = Color.green;
        }
    }

    public void OnDisable()
    {
        UiManager.instance.OnButtonPress.RemoveListener(SetButtonPressed);
        button.image.color = Color.white;
    }

    public void OnButtonClick()
    {
        UiManager.instance.ActivateButton(barrelId);
    }

    public void SetButtonPressed(int buttonId)
    {
        if (buttonId == barrelId)
        {
            button.image.color = Color.green;
            SetBarrelId();
        }
        else
            button.image.color = Color.white;
    }

    public void SetBarrelId()
    {
        foreach(GameObject gameObject in upgradeWindows)
        {
            gameObject.GetComponent<ButtonHandler>().barrelId = barrelId;
        }
    }
}
