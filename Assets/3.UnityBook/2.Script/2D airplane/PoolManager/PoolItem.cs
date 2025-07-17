using UnityEngine;

public class PoolItem : MonoBehaviour
{
    PoolManager poolManager;
    bool isInit = false; 

    private void Awake()
    {
        poolManager = GameObject.FindFirstObjectByType<PoolManager>();
    }

    private void OnEnable()
    {
        if (!isInit)
            isInit = true;
        else
            Invoke("ReturnObject", 3f);
    }

    void ReturnObject()
    {
        poolManager.pool.Release(gameObject);
    }
}
