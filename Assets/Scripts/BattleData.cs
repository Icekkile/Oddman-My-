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

    [SerializeField]
    private UIControls uiControls;
    [SerializeField]
    private BodySpawner spawner;

    public Body ClientPlayer;
    public MatchResults matchResult;
    public int TrophiesBonus;
    public int MoneyBonus;

    private float StartTime;
    private float EndTime;

    private void Awake()
    {
        ins = this;
    }

    public void PlayBattle ()
    {
        StartTime = Time.time;
        uiControls.ShowBattle();
        spawner.SpawnBodies();
    }

    public void EndBattle ()
    {
        ClientPlayer = null;
        EndTime = StartTime - Time.time;
        CountBonuses();
    }

    public void CountBonuses ()
    {
        //Counting your bonus money from EndTime
        //Counting your bonus trophies from your rating
    }
}
