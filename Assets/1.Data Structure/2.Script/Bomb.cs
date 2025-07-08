using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class Bomb : MonoBehaviour
{
    Rigidbody bobmRb;
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layermask; //�ٴڸ� ����� ���� ���̾�ó��

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
        Collider[] colls = Physics.OverlapSphere(transform.position, bombRange, layermask); //�迭 ����, �ʱ�ȭ �� �� ��. ���̾� ������,

        foreach(var collider in colls)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            rb.AddExplosionForce(500f, transform.position, bombRange, 1f); //���� �Ŀ�, ���� ��ġ, ����, ����            
        }
        Destroy(gameObject);
    }
}
