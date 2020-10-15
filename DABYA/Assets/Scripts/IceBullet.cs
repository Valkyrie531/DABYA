using UnityEngine;

public class IceBullet : Bullet
{
    private float duration = 2;

    /* Over-ride Bullet HitTarget function to include
     * slowing of monsters
     * 
     */
    public override void HitTarget()
    {
        Damage(target);
        SlowTarget(target);
        Destroy(gameObject);
    }

    /* Call monster slow function.
     * 
     */
    public void SlowTarget(Transform monster)
    {
        monster.GetComponent<Monster>().Slow(duration);
    }
}