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

        Vector2 temp = DetermineTargetPoint(Player.transform.position);
        SetTargetPoint(temp);

        _coolDown = Random.Range(CoolDown - 0.2f, CoolDown + 0.2f);

    }

    Vector2 DetermineTargetPoint (Vector2 strictPoint)
    {
        Vector2 temp = strictPoint;
        //
        
        //
        return temp;
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
