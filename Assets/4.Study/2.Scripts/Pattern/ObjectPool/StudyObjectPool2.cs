using UnityEngine;
using UnityEngine.Pool;

public class StudyObjectPool2 : MonoBehaviour
{
    public ObjectPool<GameObject> objPool;
    public GameObject objPrefab;

    private void Awake()
    {
        objPool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = objPool.Get();

        }
        //생성된 오브젝트에서 사용하는 기능
        //StudyObjectPool2.Instance.objPool.Releas(gameObject);
    }

    GameObject CreateObject()
    {
        GameObject obj = Instantiate(objPrefab, transform);
        obj.SetActive(false);

        return obj;
    }
    
    void GetObject(GameObject obj) //풀장 빼기
    {
        Debug.Log("풀에서 오브젝트 뽑는 기능");
        obj.SetActive(true);
    }

    void ReleaseObject(GameObject obj) //풀장 넣기
    {
        Debug.Log("풀에서 오브젝트 넣는 기능");
        obj.SetActive(false);
    }

    
}
