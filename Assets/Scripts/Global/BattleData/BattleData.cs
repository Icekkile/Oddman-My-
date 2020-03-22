using System.Linq;
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
    [SerializeField]
    private ArenaBuilder arenaBuilder;

    public MatchResults matchResult;
    public int TrophiesBonus;
    public int MoneyBonus;

    private float StartTime;
    private float EndTime;

    public Body Player;
    public List<Body> Bodies;
    public List<Body> Enemies;

    public List<GameObject> bodySPs;

    private void Awake()
    {
        ins = this;
        Enemies = new List<Body>();
        Bodies = new List<Body>();
    }

    private void ExecuteBodies (List<GameObject> spawnedBodies)
    {
        Bodies = spawnedBodies.Select((x) => x.GetComponent<Body>()).ToList();

        //player GM is always first in the spawnedBodies
        Player = Bodies[0];

        for (int i = 1; i < Bodies.Count; i++)
            Enemies.Add(Bodies[i]);
    }


    public void PlayBattle ()
    {
        StartTime = Time.time;

        arenaBuilder.Build();
        bodySPs = arenaBuilder.bodySPs;

        ExecuteBodies(spawner.SpawnBodies(bodySPs));

        uiControls.ShowBattle();
        Death.ins.StartNew();

        Death.ins.PlayerDeathEvent += OnPlayerDeath;
        Death.ins.EnemyDeathEvent += OnEnemyDeath;
    }

    public void OnEnemyDeath (Body killed)
    {
        Enemies.Remove(killed);

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
        EndTime = Time.time - StartTime;
        matchResult = result;
        DestroyBodies();
        uiControls.ShowEnd();
        CountBonuses();
    }

    private void DestroyBodies ()
    {
        foreach(Body body in Bodies)
        {
            Destroy(body.gameObject);
        }
        Bodies.Clear();
    }

    public void CountBonuses ()
    {
        //Counting your bonus money from EndTime
        //Counting your bonus trophies from your rating
    }
}
