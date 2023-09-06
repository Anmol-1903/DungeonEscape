using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is Null");
            }
            return _instance;
        }
    }

    [SerializeField] TextMeshProUGUI _gemsText;
    [SerializeField] TextMeshProUGUI _gemsCountText;
    [SerializeField] Slider _healthBar;

    private void Awake()
    {
        _instance = this;
    }
    public void OpenShop(int _gemCount)
    {
        _gemsText.text = _gemCount.ToString() + "G";
    }
    public void UpdateGems(int _gemCount)
    {
        _gemsCountText.text = _gemCount.ToString() + "G";
    }
    public void UpdateLives(int _health)
    {
        _healthBar.value = _health;
    }
    public void UpdateLivesMaxHealth(int _health)
    {
        _healthBar.maxValue = _health;
    }
}