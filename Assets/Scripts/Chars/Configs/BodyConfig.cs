using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodyConfig", menuName = "BodyConfig")]
public class BodyConfig : ScriptableObject
{
    public float Stamina;
    public float decreaseOnMove;
    public float staminaRegen;

    public float CoolDown;
}
