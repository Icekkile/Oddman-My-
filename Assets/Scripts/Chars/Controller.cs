using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Body), typeof(CardContainer))]
public class Controller : MonoBehaviour
{
    public Body body;

    public BodyConfig config;
    
    public float Stamina;

    private void Start()
    {
        Init();
    }

    public virtual void Init ()
    {
        DetermineRequirements();
    }

    public virtual void DetermineRequirements()
    {
        body = gameObject.GetComponent<Body>();
        Stamina = config.Stamina;
    }

    public virtual void SayToBody(Vector2 destination)
    {
        StaminaDecrease(0);
        body.SetTargetPoint(destination);
    }

    public virtual void StaminaDecrease(float bonusFactor)
    {
        if (Stamina >= 0 + config.decreaseOnMove)
            Stamina -= config.decreaseOnMove + bonusFactor;
    }

    public virtual void StaminaRegen(float bonusFactor)
    {
        if (Stamina <= config.Stamina - config.staminaRegen)
            Stamina += (config.staminaRegen + bonusFactor) * Time.deltaTime;
    }
}
