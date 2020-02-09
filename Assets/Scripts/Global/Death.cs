using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public static Death ins;

    public delegate void DeathDeleg(Body killed);
    public event DeathDeleg PlayerDeathEvent;
    public event DeathDeleg EnemyDeathEvent;

    private void Start()
    {
        ins = this;
    }

    public void StartNew ()
    {
        Clear();
    }

    public void EInvoke (Body killed)
    {
        if (killed.card.Contains("Player") && ins.PlayerDeathEvent != null)
            ins.PlayerDeathEvent(killed);
        else if (killed.card.Contains("Enemy") && ins.EnemyDeathEvent != null)
            ins.EnemyDeathEvent(killed);
    }

    private void Clear ()
    {
        ins.PlayerDeathEvent = null;
        ins.EnemyDeathEvent = null;
    }
}

