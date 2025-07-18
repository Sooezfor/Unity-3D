using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(bombEffect); //파티클 생성1
        eff.transform.position = transform.position; //파티클 위치 초기화

        Destroy(gameObject);
    }
}
