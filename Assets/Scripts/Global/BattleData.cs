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

    public MatchResults matchResult;
    public int TrophiesBonus;
    public int MoneyBonus;

    private float StartTime;
    private float EndTime;

    public Body Player;
    public List<GameObject> Bodies;
    public List<GameObject> Enemies;

    private void Awake()
    {
        ins = this;
        Enemies = new List<GameObject>();
        Bodies = new List<GameObject>();
    }

    private void FindBodies ()
    {
        Bodies = CardSystem.ins.FindManyByCard("Body");
    }

    private void FindEnemies ()
    {
        Enemies = CardSystem.ins.FindManyByCard("Enemy");
    }

    public void PlayBattle ()
    {
        StartTime = Time.time;
        spawner.SpawnBodies();
        uiControls.ShowBattle();
        FindBodies();
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
        Player = null;
        EndTime = StartTime - Time.time;
        matchResult = result;
        DestroyBodies();
        uiControls.ShowEnd();
        CountBonuses();
    }

    private void DestroyBodies ()
    {
        foreach(GameObject go in Bodies)
        {
            Destroy(go);
        }
    }

    public void CountBonuses ()
    {
        //Counting your bonus money from EndTime
        //Counting your bonus trophies from your rating
    }
}
