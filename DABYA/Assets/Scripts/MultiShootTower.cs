using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShootTower : Tower
{
    private int noOfShots = 3;
    
    /* Decrease fire rate so tower shoots less often
     * 
     */
    public MultiShootTower()
    {
        fireRate = 5;
    }

    /* Shoot multiple bullets in quick succession.
     * 
     */
    public IEnumerator ShootMulti()
    {
        for (int i = 0; i < noOfShots; i++)
        {
            MakeBullet();
            yield return new WaitForSeconds(0.25f);
        }
    }

    public override void Shoot()
    {
        AudioManager.instance.Play("MultiBullet");
        StartCoroutine(ShootMulti());
    }

    /* Instantiate bullets.
     * 
     */
    public void MakeBullet()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet Bullet = bulletGo.GetComponent<Bullet>();

        if (Bullet != null)
            Bullet.setDamage(fireDamage);
        Bullet.Seek(target);

    }
}
