using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData ins;

    public int Trophies;
    public int Money;

    private void Awake()
    {
        ins = this;
    }
}
