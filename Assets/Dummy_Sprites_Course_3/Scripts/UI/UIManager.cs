using TMPro;
using UnityEngine;
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

    private void Awake()
    {
        _instance = this;
    }
    public void OpenShop(int _gemCount)
    {
        _gemsText.text = _gemCount.ToString() + "G";
    }
}