using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MatchResults
{
    Win,
    Lose,
    Draw,
}

public class BattleData : MonoBehaviour
{
    public static BattleData ins;

    public Body ClientPlayer;
    public MatchResults matchResult;

    private void Awake()
    {
        ins = this;
    }

    public void StartNew ()
    {
        ClientPlayer = null;
    }
}
