﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int roundNumber;
    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
}
