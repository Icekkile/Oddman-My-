using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour, IController
{
    public CharacterMovement pm;

    public float CoolDown;
    private float _coolDown;

    private void Start()
    {

    }

    public void Actioned ()
    {
        _coolDown = CoolDown;
    }

    public bool CountCoolDown()
    {
        _coolDown -= _coolDown <= 0 ? 0 : Time.deltaTime;

        return _coolDown <= 0;
    }

    public void SetTargetPoint(Vector2 TargetPoint)
    {
        pm.SetTargetPoint(TargetPoint);
    }
}
