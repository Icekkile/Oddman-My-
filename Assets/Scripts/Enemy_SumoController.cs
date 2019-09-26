using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SumoController : MonoBehaviour, IController
{
    public CharacterMovement em;
    public GameObject Player;

    public float CoolDown;
    private float _coolDown;

    private void Update()
    {
        if (!CountCoolDown()) return;

        SetTargetPoint(Player.transform.position);
        _coolDown = CoolDown;

    }

    public void SetTargetPoint (Vector2 targetPoint)
    {
        em.SetTargetPoint(targetPoint);
    }

    public bool CountCoolDown()
    {
        _coolDown -= _coolDown <= 0 ? 0 : Time.deltaTime;

        if (_coolDown > 0) return false;
        return true;
    }
}
