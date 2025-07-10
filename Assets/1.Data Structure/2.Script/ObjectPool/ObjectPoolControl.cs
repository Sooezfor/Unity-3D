using UnityEngine;

public class ObjectPoolControl : MonoBehaviour
{
    public ObjectPoolQueue pool;
    public Transform shootPos;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) //풀장에 있는 것 꺼내 쓰기
        {
            GameObject bullet = pool.Dequeueobj();
            bullet.transform.position = shootPos.position;
        }
    }
}
