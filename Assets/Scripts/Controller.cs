using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour, IController
{
    public CharacterMovement pm;

    public float CoolDown;
    private float _coolDown;

    public bool actioned;

    public void Update ()
    {
        if (_coolDown > 0)
            _coolDown -= Time.deltaTime;
        actioned = _coolDown > 0;
    }

    public void SetTargetPoint(Vector2 TargetPoint)
    {
        pm.SetTargetPoint(TargetPoint);
        _coolDown = CoolDown;
    }
}
