using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public List<BarrelButtons> barrelList = new List<BarrelButtons>();

    public void ActivateNextBarrel(int barrelId)
    {
        for(int i = 0; i < barrelList.Count; i++)
        {
            Debug.Log("Ui activates" + barrelId);
            if (barrelList[i].barrelId == barrelId)
                barrelList[i].gameObject.SetActive(true);
        }
    }
}
