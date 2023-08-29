using UnityEngine;
public class Acid : MonoBehaviour
{
    [SerializeField] float _speed;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IDamageable hit = other.GetComponent<IDamageable>();
            if(hit != null)
            {
                hit.Damage();
            }
        }
    }
}