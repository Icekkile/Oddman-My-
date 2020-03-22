using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Arena", menuName = "Arena")]
public class ArenaConfig : ScriptableObject
{
    public List<GameObject> Arena;
    public List<GameObject> SpawnPoints;
}
