using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    Movement _player;

    [SerializeField] GameObject _shop;
    int _itemCost;
    int _currentSelectedItem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _shop.SetActive(true);
            _player = other.GetComponent<Movement>();
            if (_player != null)
            {
                UIManager.Instance.OpenShop(_player._diamonds);
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
    /*
    0 = flame sword
    1 = boots of flight
    2 = key of castle
     */
    public void SelectItem(int _item)
    {
        _currentSelectedItem = _item;
    }
    public void SelectCost(int _cost)
    {
        _itemCost = _cost;
    }
    public void BuyItem()
    {
        if(_player._diamonds >= _itemCost)
        {
            _player._diamonds -= _itemCost;
            switch (_currentSelectedItem)
            {
                case 2:
                    GameManager.Instance.HasKeyToCastle = true;
                    break;
            }
        }
        else
        {
            // Can't Afford
        }
    }
}