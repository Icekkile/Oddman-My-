using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleData : MonoBehaviour
{
    public static BattleData instance;

    public List<GameObject> Characters;

    private void Start()
    {
        Characters.Clear();
        Characters.AddRange(GameObject.FindGameObjectsWithTag("Character"));
    }


}
