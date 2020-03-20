using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour
{
    GameObject playerSpawnPrefab;
    List<GameObject> enemySpawnPrefabs;

    public List<GameObject> SpawnBodies ()
    {
        List<GameObject> spawnedBodies = new List<GameObject>();
        
        spawnedBodies.Add(SpawnPlayer());
        spawnedBodies.AddRange(SpawnEnemies());

        return spawnedBodies;
    }


    //returns Player
    private GameObject SpawnPlayer ()
    {
        playerSpawnPrefab = LocatePlayerSpawnPoint();
        PlayerSpawnPoint spawnPoint = playerSpawnPrefab.GetComponent<PlayerSpawnPoint>();
        GameObject prefab = spawnPoint.playerPrefab;
        Vector2 point = (Vector2)spawnPoint.point.position;

        return Instantiate(prefab, point, Quaternion.identity);

    }

    private List<GameObject> SpawnEnemies ()
    {
        enemySpawnPrefabs = LocateEnemySpawnPoints();
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

    private GameObject LocatePlayerSpawnPoint ()
    {
        //WILL BE DELETED IN FUTURE
        return GameObject.FindGameObjectWithTag("PlayerSpawnPoint");
    }

    private List<GameObject> LocateEnemySpawnPoints ()
    {
        //WILL BE DELETED IN FUTURE
        return GameObject.FindGameObjectsWithTag("EnemySpawnPoint").ToList<GameObject>();
    }
}
