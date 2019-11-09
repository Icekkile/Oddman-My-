using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleData : MonoBehaviour
{
    public static BattleData ins;

    public Body ClientPlayer;

    private void Awake()
    {
        ins = this;
    }
}
