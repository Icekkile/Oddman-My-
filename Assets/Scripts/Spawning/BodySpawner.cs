using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour
{
    GameObject playerSP;
    List<GameObject> enemySPs;

    public void SpawnBodies ()
    {
        SpawnPlayer();
        SpawnEnemies();
    }

    private void SpawnPlayer ()
    {
        playerSP = LocatePlayerSpawnPoint();
        PlayerSpawnPoint spawnPoint = playerSP.GetComponent<PlayerSpawnPoint>();
        GameObject prefab = spawnPoint.playerPrefab;
        Vector2 point = (Vector2)spawnPoint.point.position;

        Instantiate(prefab, point, Quaternion.identity);

    }

    private void SpawnEnemies ()
    {
        enemySPs = LocateEnemySpawnPoints();
        List<EnemySpawnPoint> spawnPoints = new List<EnemySpawnPoint> ();
        List<GameObject> prefabs = new List<GameObject> ();
        List<Vector2> points = new List<Vector2> ();

        for (int i = 0; i < enemySPs.Count; i++)
        {
            spawnPoints.Add(enemySPs[i].GetComponent<EnemySpawnPoint>());
            prefabs.Add(spawnPoints[i].enemyPrefab);
            points.Add((Vector2)spawnPoints[i].point.position);
        }

        for (int i = 0; i < enemySPs.Count; i++)
        {
            Instantiate(prefabs[i], points[i], Quaternion.identity);
        }
    }

    private GameObject LocatePlayerSpawnPoint ()
    {
        return CardSystem.ins.FindByCard("PlayerSpawnPoint");
    }

    private List<GameObject> LocateEnemySpawnPoints ()
    {
        return CardSystem.ins.FindManyByCard("EnemySpawnPoint");
    }
}
