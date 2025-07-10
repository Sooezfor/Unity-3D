using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();
    public GameObject objPrefabs; //생성할 오브젝트 프리팹
    public Transform parent; //생성할 부모 위치

    private void Start()
    {
        CreateObj(); 
    }
    void CreateObj() // 오브젝트 생성하는 기능(풀장 채우기)
    {
        for(int i = 0; i < 100; i++)
        {
            GameObject obj = Instantiate(objPrefabs, parent); //오브젝트 생성하고 계층구조 parent 의 자시으로 옮김) 

            EnqueueObj(obj);
        }
    }

    public void EnqueueObj(GameObject newobj)
    {
        objQueue.Enqueue(newobj);
        newobj.SetActive(false); 
    }

    public GameObject Dequeueobj()
    {
        if(objQueue.Count < 10)       
            CreateObj();
        
        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);

         return obj;
    }
}
