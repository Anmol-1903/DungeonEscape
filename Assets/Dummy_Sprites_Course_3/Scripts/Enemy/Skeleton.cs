using UnityEngine;
public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = health;
    }
    public override void Movement()
    {
        base.Movement();
        Vector3 dir = player.transform.position - transform.position;
        if (dir.x > 0 && anim.GetBool("Combat") == true)
        {
            sprite.flipX = false;
        }
        else if (dir.x < 0 && anim.GetBool("Combat") == true)
        {
            sprite.flipX = true;
        }
    }
    public void Damage()
    {
        Health--;
        isHit = true;
        anim.SetTrigger("Hit");
        anim.SetBool("Combat", true);
        if(Health < 1)
        {
            Destroy(gameObject);
        }
    }
}