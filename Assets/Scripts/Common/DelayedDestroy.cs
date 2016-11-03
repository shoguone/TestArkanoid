using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    public float delay = 1f;
    
    void Awake()
    {
        Destroy(gameObject, delay);
    }
}
