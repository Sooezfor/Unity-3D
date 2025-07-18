using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    float moveSpeed = 100f;
    bool isMove = true; //ó���� ������ ���ư��ϱ�

    private void Update()
    {
        if(isMove) //isMove�� true�� ���� ���ư�.        
            transform.position += transform.up * moveSpeed * Time.deltaTime;        
    }

    private void OnTriggerEnter(Collider other)
    {
        var closetPos = other.ClosestPoint(transform.position);
        transform.position = closetPos; 

        transform.SetParent(other.transform);  //ȭ���� ��ġ�� �÷��̾� ��ġ�� �־��ֱ�
        isMove = false;     
    }
}
