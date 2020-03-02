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
        if (!IsStamina(0))
            return;
        StaminaDecrease(0);
        body.Move(destination);
    }

    public bool IsStamina (float bonusFactor)
    {
        return Stamina >= 0 + config.decreaseOnMove + bonusFactor;
    }

    public virtual void StaminaDecrease(float bonusFactor)
    {
        Stamina -= config.decreaseOnMove + bonusFactor;
    }

    public virtual void StaminaRegen(float bonusFactor)
    {
        if (Stamina <= config.Stamina - config.staminaRegen)
            Stamina += (config.staminaRegen + bonusFactor) * Time.deltaTime;
    }
}
