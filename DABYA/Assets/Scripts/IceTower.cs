using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower
{
    public IceTower()
    {
        fireDamage = 10f * DifficultySelection.towerStatModifier;
    }

    /* Over-ride shoot function to shoot ice bullets
     * instead of regular bullets.
     * 
     */
    public override void Shoot()
    {
        AudioManager.instance.Play("IceBullet");
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        IceBullet iceBullet = bulletGo.GetComponent<IceBullet>();

        if (iceBullet != null)
            iceBullet.setDamage(fireDamage);
            iceBullet.Seek(target);
    }
}
