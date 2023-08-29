using UnityEngine;
public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider _spider;
    private void Awake()
    {
        _spider = transform.GetComponentInParent<Spider>();
    }
    public void FireAcid()
    {
        _spider.Attack();
    }
}