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
            Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().Health);
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().Health <= 0)
            {
                GetComponentInParent<Animator>().SetBool("Combat", false);
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetTrigger("Death");

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