﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EDeathReason
{

}

public class Death : MonoBehaviour
{
    public static Death instance;

    public delegate void DeathDeleg(GameObject killed, GameObject killer);
    public event DeathDeleg DeathEvent;

    private void Awake()
    {
        instance = this;
        Clear();
    }

    private void Start()
    {
        
    }

    public void EInvoke (GameObject killed, GameObject killer)
    {
        if (DeathEvent != null)
            DeathEvent(killed, killer);
    }

    private void Clear ()
    {
        DeathEvent = null;
    }
}
