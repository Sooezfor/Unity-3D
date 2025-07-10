using UnityEngine;

public class ObjectPoolControl : MonoBehaviour
{
    public ObjectPoolQueue pool;
    public Transform shootPos;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) //Ǯ�忡 �ִ� �� ���� ����
        {
            GameObject bullet = pool.Dequeueobj();
            bullet.transform.position = shootPos.position;
        }
    }
}
