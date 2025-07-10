using UnityEngine;

public class PoolObject : MonoBehaviour
{
    ObjectPoolQueue pool; //돌아가야 하는 장소
    float bulletSpeed = 100f; 

    private void Awake()
    {
        pool = FindFirstObjectByType<ObjectPoolQueue>(); //스크립트 있는 오브젝트 찾음
    }

    private void OnEnable()
    {
        Invoke("ReturnPool", 3f);
    }

    private void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * bulletSpeed; 
    }

    void ReturnPool()
    {
        pool.EnqueueObj(gameObject);
    }
}
