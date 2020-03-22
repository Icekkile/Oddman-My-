using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour
{
    GameObject playerSpawnPrefab;
    List<GameObject> enemySpawnPrefabs;

    public List<GameObject> SpawnBodies (List<GameObject> bodySPs)
    {
        enemySpawnPrefabs = new List<GameObject>();
        LocateSpawnPoints(bodySPs, ref playerSpawnPrefab, ref enemySpawnPrefabs);

        List<GameObject> spawnedBodies = new List<GameObject>();
        
        spawnedBodies.Add(SpawnPlayer());
        spawnedBodies.AddRange(SpawnEnemies());

        return spawnedBodies;
    }


    //returns Player
    private GameObject SpawnPlayer ()
    {
        PlayerSpawnPoint spawnPoint = playerSpawnPrefab.GetComponent<PlayerSpawnPoint>();
        GameObject prefab = spawnPoint.playerPrefab;
        Vector2 point = (Vector2)spawnPoint.point.position;

        return Instantiate(prefab, point, Quaternion.identity);

    }

    private List<GameObject> SpawnEnemies ()
    {
        List<GameObject> enemies = new List<GameObject>();

        for (int i = 0; i < enemySpawnPrefabs.Count; i++)
        {
            EnemySpawnPoint spawnPoint = new EnemySpawnPoint();
            spawnPoint = enemySpawnPrefabs[i].GetComponent<EnemySpawnPoint>();

            GameObject prefab = new GameObject();
            prefab = spawnPoint.enemyPrefab;

            Vector2 point = (Vector2)spawnPoint.point.position;

            GameObject gm = Instantiate(prefab, point, Quaternion.identity);
            enemies.Add(gm);
        }
        return enemies;
    }

    private void LocateSpawnPoints (List<GameObject> bodySPs, ref GameObject plSP, ref List<GameObject> enSPs)
    {
        foreach (GameObject go in bodySPs)
        {
            if (go.tag == "PlayerSpawnPoint")
                plSP = go;
            else if (go.tag == "EnemySpawnPoint")
                enSPs.Add(go);
        }
    }
}
