using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();
    public GameObject objPrefabs; //������ ������Ʈ ������
    public Transform parent; //������ �θ� ��ġ

    private void Start()
    {
        CreateObj(); 
    }
    void CreateObj() // ������Ʈ �����ϴ� ���(Ǯ�� ä���)
    {
        for(int i = 0; i < 100; i++)
        {
            GameObject obj = Instantiate(objPrefabs, parent); //������Ʈ �����ϰ� �������� parent �� �ڽ����� �ű�) 

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
