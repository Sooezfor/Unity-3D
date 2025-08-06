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
        //������ ������Ʈ���� ����ϴ� ���
        //StudyObjectPool2.Instance.objPool.Releas(gameObject);
    }

    GameObject CreateObject()
    {
        GameObject obj = Instantiate(objPrefab, transform);
        obj.SetActive(false);

        return obj;
    }
    
    void GetObject(GameObject obj) //Ǯ�� ����
    {
        Debug.Log("Ǯ���� ������Ʈ �̴� ���");
        obj.SetActive(true);
    }

    void ReleaseObject(GameObject obj) //Ǯ�� �ֱ�
    {
        Debug.Log("Ǯ���� ������Ʈ �ִ� ���");
        obj.SetActive(false);
    }

    
}
