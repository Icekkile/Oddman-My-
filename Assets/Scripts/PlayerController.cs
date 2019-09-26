using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour , IController
{
    public CharacterMovement pm;

    public float CoolDown;
    private float _coolDown;

    private void Update()
    {
        if (!CountCoolDown()) return;

        if (Input.GetMouseButton(0))
        {
            Vector2 pointToMove = ControllerInput();
            SetTargetPoint(pointToMove);
            _coolDown = CoolDown;
        }
    }

    //ok?
    public bool CountCoolDown ()
    {
        _coolDown -= _coolDown <= 0 ? 0 : Time.deltaTime;

        if (_coolDown > 0) return false;
        return true;
    }

    public void SetTargetPoint(Vector2 TargetPoint)
    {
        pm.SetTargetPoint(TargetPoint);
    }

    Vector2 ControllerInput ()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
