using UnityEngine;
public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    [SerializeField] GameObject _acidPrefab;
    public override void Init()
    {
        base.Init();
        Health = health;
    }
    public override void Movement()
    {
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
    public void Attack()
    {
        Instantiate(_acidPrefab, transform.position, Quaternion.identity);
    }
}