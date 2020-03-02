using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller), typeof(Body), typeof(CharacterMovement))]
public class ConfigDisplay : MonoBehaviour
{
    public BodyConfig bodyConfig;
    public ChestConfig chestConfig;
    //public WeaponConfig weaponConfig;

    private Controller controller;
    private Body body;
    private PunchAction punch;
    private CharacterMovement movement;

    private void OnEnable()
    {
        Init();
        
        controller.config = bodyConfig;
        body.config = bodyConfig;
        movement.massBonus = GetMassBonus();
        
    }

    private float GetMassBonus ()
    {
        float massBonus = 0;
        massBonus += chestConfig.Mass;
        return massBonus;
    }

    private void Init ()
    {
        controller = GetComponent<Controller>();
        body = GetComponent<Body>();
        punch = GetComponent<PunchAction>();
        movement = GetComponent<CharacterMovement>();
    }
}
