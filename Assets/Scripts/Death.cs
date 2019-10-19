using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public static Death instance;

    public delegate void DeathDeleg();
    public event DeathDeleg DeathEvent;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DeathEvent = null;
    }

    public void EInvoke ()
    {
        if (DeathEvent != null)
            DeathEvent();
    }

    public void Clear ()
    {
        DeathEvent = null;
    }
}

