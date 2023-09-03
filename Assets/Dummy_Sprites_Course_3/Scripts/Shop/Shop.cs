using UnityEngine;
public class Shop : MonoBehaviour
{
    [SerializeField] GameObject _shop;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _shop.SetActive(true);
            Movement mov = other.GetComponent<Movement>();
            if (mov != null)
            {
                UIManager.Instance.OpenShop(mov._diamonds);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _shop.SetActive(false);
        }
    }
    public void SelectItem()
    {
        Debug.Log("Selected");
    }
}