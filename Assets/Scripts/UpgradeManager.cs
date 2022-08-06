using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public List<Barrel> barrels = new List<Barrel>();

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
}
