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

    private GameObject CreateObject()//만들기
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false); //끈 상태로 넣기 

        return obj; //반납
    }

    private void OnGetObject(GameObject obj) //꺼내기
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        obj.transform.position = Vector3.zero;
        obj.SetActive(true); 
    }

    void OnReleaseObject(GameObject obj) //집어넣기
    {
        obj.SetActive(false);
    }

    void OnDestoryObject(GameObject obj) //파괴하기
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
