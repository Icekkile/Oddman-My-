using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodyConfig", menuName = "BodyConfig")]
public class BodyConfig : ScriptableObject
{
    public ChestConfig chest;
    public WeaponConfig weapon;

    public float Stamina;
    public float decreaseOnMove;
    public float staminaRegen;

    public float CoolDown;
}
