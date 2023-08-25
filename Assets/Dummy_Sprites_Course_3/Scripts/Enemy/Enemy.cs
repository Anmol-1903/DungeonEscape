using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected int _speed;
    [SerializeField] protected int _gems;

    [SerializeField] protected Transform A,B;
    public virtual void Attack()
    {

    }
    public abstract void Update();
}