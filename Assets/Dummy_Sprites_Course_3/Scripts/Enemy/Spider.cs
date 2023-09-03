using UnityEngine;
public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    [SerializeField] GameObject _acidPrefab;
    [SerializeField] Transform _container;
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
            isDead = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            GameObject dia = Instantiate(_diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            dia.GetComponent<Diamond>()._gems = gems;
            anim.SetTrigger("Death");
        }
    }
    public void Attack()
    {
        Instantiate(_acidPrefab, transform.position, Quaternion.identity, _container);
    }
}