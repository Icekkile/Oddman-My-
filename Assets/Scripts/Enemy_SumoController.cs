using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SumoController : MonoBehaviour
{
    public Controller controller;
    public GameObject player;

    private void Start()
    {

    }


    private void Update()
    {
        if (!controller.CountCoolDown()) return;
        controller.SetTargetPoint(player.transform.position);
        controller.Actioned();
    }
}
