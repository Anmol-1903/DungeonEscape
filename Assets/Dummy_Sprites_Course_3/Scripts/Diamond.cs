using UnityEngine;
public class Diamond : MonoBehaviour
{
    public int _gems = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Movement _player = other.GetComponent<Movement>();
            if (_player)
            {
                _player.AddGems(_gems);
            }
            Destroy(gameObject);
        }
    }
}