using UnityEngine;
using System.Collections;
public class Attack : MonoBehaviour
{
    [SerializeField] float _attackCooldown;
    
    bool _canAttack = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if(damageable != null)
        {
            if (_canAttack)
            {
                damageable.Damage();
                StartCoroutine(AttackCooldown());
            }
        }
    }
    IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }
}