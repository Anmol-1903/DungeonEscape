using UnityEngine;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is Null");
            }
            return _instance;
        }
    }

    public bool HasKeyToCastle { get; set; }
    private void Awake()
    {
        _instance = this;
    }
}