using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    public GameObject prefab;

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(CreateObject, OnGetObject, OnReleaseObject, OnDestoryObject, defaultCapacity:10, maxSize: 100);
    }

    private GameObject CreateObject()//�����
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false); //�� ���·� �ֱ� 

        return obj; //�ݳ�
    }

    private void OnGetObject(GameObject obj) //������
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        obj.transform.position = Vector3.zero;
        obj.SetActive(true); 
    }

    void OnReleaseObject(GameObject obj) //����ֱ�
    {
        obj.SetActive(false);
    }

    void OnDestoryObject(GameObject obj) //�ı��ϱ�
    {
        Destroy(obj);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = pool.Get();
            obj.SetActive(true);
        }
    }
}
