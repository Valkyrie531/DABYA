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
        transform.GetComponent<Animator>().SetTrigger("ShootBullet");
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        IceBullet iceBullet = bulletGo.GetComponent<IceBullet>();

        if (iceBullet != null)
            iceBullet.SetDamage(fireDamage);
            iceBullet.Seek(target);
    }
}
