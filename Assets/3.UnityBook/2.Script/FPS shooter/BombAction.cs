using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(bombEffect); //��ƼŬ ����1
        eff.transform.position = transform.position; //��ƼŬ ��ġ �ʱ�ȭ

        Destroy(gameObject);
    }
}
