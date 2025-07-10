using UnityEngine;

public class PoolObject : MonoBehaviour
{
    ObjectPoolQueue pool; //���ư��� �ϴ� ���
    float bulletSpeed = 100f; 

    private void Awake()
    {
        pool = FindFirstObjectByType<ObjectPoolQueue>(); //��ũ��Ʈ �ִ� ������Ʈ ã��
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
