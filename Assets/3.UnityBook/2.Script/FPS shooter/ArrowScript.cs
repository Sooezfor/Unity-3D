using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    float moveSpeed = 100f;
    bool isMove = true; //처음엔 무조건 날아가니까

    private void Update()
    {
        if(isMove) //isMove가 true일 때만 날아감.        
            transform.position += transform.up * moveSpeed * Time.deltaTime;        
    }

    private void OnTriggerEnter(Collider other)
    {
        var closetPos = other.ClosestPoint(transform.position);
        transform.position = closetPos; 

        transform.SetParent(other.transform);  //화살의 위치를 플레이어 위치에 넣어주기
        isMove = false;     
    }
}
