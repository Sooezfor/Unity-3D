using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class Bomb : MonoBehaviour
{
    Rigidbody bobmRb;
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layermask; //바닥면 남기기 위해 레이어처리

    private void Awake()
    {
        bobmRb = GetComponent<Rigidbody>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);
        BombForce();
    }

    void BombForce()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, bombRange, layermask); //배열 생성, 초기화 다 한 것. 레이어 구분함,

        foreach(var collider in colls)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            rb.AddExplosionForce(500f, transform.position, bombRange, 1f); //폭발 파워, 폭발 위치, 범위, 높이            
        }
        Destroy(gameObject);
    }
}
