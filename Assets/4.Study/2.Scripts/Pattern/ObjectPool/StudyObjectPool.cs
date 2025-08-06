using System.Collections.Generic;
using UnityEngine;

public class StudyObjectPool : StudyGenericSingleton<StudyObjectPool>
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();
    public GameObject objPrefab; //������ ������Ʈ 

    public int poolSize = 100;

    private void Start()
    {
        CreateObject();
     
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(objQueue.Count < 10) //���� �� �� �� ���϶��            
                CreateObject();
            
            GameObject obj = DequeueObject(); //Ǯ���� ������Ʈ �̾Ƽ� ���
            obj.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        }

        //������ ������Ʈ���� ����ϴ� ���
        //StudyObjectPool.Instance.EnqueueObject(gameObject);
    }
    public void EnqueueObject(GameObject obj) //������Ʈ�� Ǯ�忡 �ֱ� 
    {
        objQueue.Enqueue(obj);
        obj.SetActive(false);
    }

    public GameObject DequeueObject() //������Ʈ Ǯ�忡�� ����
    {
        GameObject obj = objQueue.Dequeue();

        return obj;
    }

    void CreateObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(objPrefab, transform);
            EnqueueObject(newObj);
        }
    }

}
