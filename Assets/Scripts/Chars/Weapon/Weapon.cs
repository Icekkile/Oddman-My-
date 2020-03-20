using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Body thisBody;
    WeaponConfig weaponConfig;

    IWeaponUser weaponUser;
    float useTime;

    public Weapon (Body bodyON)
    {
        thisBody = bodyON;
    }

    public void SetWeapon(WeaponConfig config)
    {
        if (config == null)
            return;

        weaponConfig = config;

        if (weaponConfig is LRConfig)
            weaponUser = new LRUser(thisBody.gameObject, (weaponConfig as LRConfig).staminaDamage);

        else if (weaponConfig is MeleeConfig)
            weaponUser = new MeleeUser();

        //Now we can attack instantly
        useTime = weaponConfig.speed;
    }

    private void Update()
    {
        if (weaponUser == null)
            return;

        CountTime();

        if (useTime >= weaponConfig.speed)
            Attack();
        
    }

    private void Attack ()
    {
        weaponUser.UseIt();
        useTime = 0;
    }

    private void CountTime ()
    {
        if (useTime <= weaponConfig.timeMax)
            useTime += Time.deltaTime;
    }
}
