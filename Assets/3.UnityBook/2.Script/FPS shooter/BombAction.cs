using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    public int attackPower = 10;
    public float explosionRadius = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, explosionRadius, 1 << 9); //enemy���� 
        //����ź�� �浹�� ��ġ���� Radius ������ŭ 9�� ���̾ ���� ����� colls �� �Ҵ�
        
        for(int i = 0; i<colls.Length; i++)
        {
            colls[i].GetComponent<EnemyFSM>().HitEnemy(attackPower);
            //�ݶ��̴��� ���� ����� ��ũ��Ʈ�� �����ؼ� �Լ� ����
        }

        GameObject eff = Instantiate(bombEffect); //��ƼŬ ����1
        eff.transform.position = transform.position; //��ƼŬ ��ġ �ʱ�ȭ

        Destroy(gameObject);
    }
}
