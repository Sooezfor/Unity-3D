using System.Collections.Generic;
using UnityEngine;

public class StudyObjectPool : StudyGenericSingleton<StudyObjectPool>
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();
    public GameObject objPrefab; //생성될 오브젝트 

    public int poolSize = 100;

    private void Start()
    {
        CreateObject();
     
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(objQueue.Count < 10) //남은 개 열 개 이하라면            
                CreateObject();
            
            GameObject obj = DequeueObject(); //풀에서 오브젝트 뽑아서 사용
            obj.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        }

        //생성된 오브젝트에서 사용하는 기능
        //StudyObjectPool.Instance.EnqueueObject(gameObject);
    }
    public void EnqueueObject(GameObject obj) //오브젝트를 풀장에 넣기 
    {
        objQueue.Enqueue(obj);
        obj.SetActive(false);
    }

    public GameObject DequeueObject() //오브젝트 풀장에서 빼기
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
