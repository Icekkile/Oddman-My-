using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SumoController : MonoBehaviour
{
    public Controller controller;
    public GameObject player;

    private void Update()
    {
        if (controller.actioned) return;
        controller.SetTargetPoint(player.transform.position);
    }
}
