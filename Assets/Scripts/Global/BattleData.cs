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

    public List<GameObject> Enemies;

    private void Awake()
    {
        ins = this;
        Enemies = new List<GameObject>();
    }

    private void FindEnemies ()
    {
        Enemies = CardSystem.ins.FindManyByCard("Enemy");
    }

    public void PlayBattle ()
    {
        StartTime = Time.time;
        uiControls.ShowBattle();
        spawner.SpawnBodies();
        FindEnemies();
        Death.ins.StartNew();

        Death.ins.PlayerDeathEvent += OnPlayerDeath;
        Death.ins.EnemyDeathEvent += OnEnemyDeath;
    }

    public void OnEnemyDeath (Body killed)
    {
        FindEnemies();
        if (Enemies.Count == 0)
            EndBattle(MatchResults.Win);
    }

    public void OnPlayerDeath (Body killed)
    {
        EndBattle(MatchResults.Lose);
    } 

    public void EndBattle (MatchResults result)
    {
        ClientPlayer = null;
        EndTime = StartTime - Time.time;
        matchResult = result;
        uiControls.ShowEnd();
        CountBonuses();
    }

    public void CountBonuses ()
    {
        //Counting your bonus money from EndTime
        //Counting your bonus trophies from your rating
    }
}
