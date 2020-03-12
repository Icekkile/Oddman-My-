using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller), typeof(Body), typeof(CharacterMovement))]
public class ConfigDisplay : MonoBehaviour
{
    public BodyConfig bodyConfig;

    private Body body;

    private void OnEnable()
    {
        Init();

        body.config = bodyConfig;
        body.controller.config = bodyConfig;
        
        float massBonus = GetMassBonus();
        body.movement.massBonus = massBonus;
        body.controller.bonusOnMove = massBonus;

        body.weapon.SetWeapon(bodyConfig.weapon);
    }

    private float GetMassBonus ()
    {
        float massBonus = 0;
        massBonus += bodyConfig.chest.Mass;
        return massBonus;
    }

    private void Init ()
    {
        if (body == null)
            body = GetComponent<Body>();
    }
}
