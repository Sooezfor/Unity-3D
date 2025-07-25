using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    public int attackPower = 10;
    public float explosionRadius = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, explosionRadius, 1 << 9); //enemy까지 
        //수류탄이 충돌한 위치에서 Radius 범위만큼 9번 레이어를 가진 대상을 colls 에 할당
        
        for(int i = 0; i<colls.Length; i++)
        {
            colls[i].GetComponent<EnemyFSM>().HitEnemy(attackPower);
            //콜라이더에 닿은 대상의 스크립트에 접근해서 함수 실행
        }

        GameObject eff = Instantiate(bombEffect); //파티클 생성1
        eff.transform.position = transform.position; //파티클 위치 초기화

        Destroy(gameObject);
    }
}
