using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SumoController : MonoBehaviour
{
    public Controller controller;

    private void Update()
    {
        if (controller.actioned) return;
        controller.SetTargetPoint(BattleData.instance.Player.transform.position);
    }
}
