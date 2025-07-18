using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{    
    public GameObject arrowPrefab;
    public Transform shootPos;
    bool isShoot;

    private void Update()
    {
        Ray ray = new Ray(shootPos.position, transform.forward); //시작점, 방향
        RaycastHit hit; //레이저 닿은 대상 

        bool isTargeting = Physics.Raycast(ray, out hit);

        if(isTargeting && !isShoot) //타겟팅은 true이고 쏘고 있는 상태가 아닐 때만 실행        
            StartCoroutine(ShootRoutine());        
    }

    IEnumerator ShootRoutine()
    {
       isShoot = true; 

        GameObject arrow = Instantiate(arrowPrefab, transform); //생성할 프리팹, 생성되는 부모 오브젝트
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        arrow.transform.SetPositionAndRotation(shootPos.position, rot); //포지와 로테이션 같이

        yield return new WaitForSeconds(3f);
        isShoot = false; 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward); //레이저 나타나기
        //Debug.DrawRay(transform.position, transform.forward, Color.green); //레이저 어디인지 확인, 업데이트에서 실행
    }
}
