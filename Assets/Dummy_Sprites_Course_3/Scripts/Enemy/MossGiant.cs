using UnityEngine;
public class MossGiant : Enemy, IDamageable
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
    }
    public void Damage()
    {
        Health--;
        isHit = true;
        anim.SetTrigger("Hit");
        anim.SetBool("Combat", true);
        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }
}