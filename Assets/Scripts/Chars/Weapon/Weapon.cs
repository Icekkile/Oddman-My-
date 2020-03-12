using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponConfig weapon;

    IWeaponUser weaponUser;
    float useTime;

    public void SetWeapon(WeaponConfig config)
    {
        if (weapon == null)
            return;

        weapon = config;

        if (weapon is LRConfig)
            weaponUser = new LRUser();

        else if (weapon is MeleeConfig)
            weaponUser = new MeleeUser();

        //Now we can attack instantly
        useTime = weapon.speed;
    }

    private void Update()
    {
        if (weaponUser == null)
            return;

        CountTime();

        if (useTime >= weapon.speed)
            Attack();
        
    }

    private void Attack ()
    {
        weaponUser.UseIt();
        useTime = 0;
    }

    private void CountTime ()
    {
        if (useTime <= weapon.timeMax)
            useTime += Time.deltaTime;
    }
}
