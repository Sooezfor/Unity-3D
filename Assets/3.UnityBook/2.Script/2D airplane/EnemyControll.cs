using System;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public GameObject ExplosionFactory;
    Vector3 dir;
    float speed = 5f;

    private void OnEnable()
    {
        int ranValue = UnityEngine.Random.Range(0, 10); //�ý��� ������ ����Ƽ ���� �� ����Ƽ���� ���ڴٴ� ��

        if(ranValue < 7) //70�۸� �ΰ����� ���
        {
            GameObject target = GameObject.Find("Player"); //��ü �˻��ϴ� FInd ��. ��ŸƮ���� �����. 
            dir = target.transform.position - transform.position;
            dir.Normalize(); //�˾Ƽ� �����ϴ� ��� 
        }
        else // 30��        
            dir = Vector3.down;        
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.Instance.Score++; // ���� ���� ���� +1 �ؼ� ������Ƽ�� �ѱ�
      
        GameObject explosion = Instantiate(ExplosionFactory);
        explosion.transform.position = transform.position; 

        if (other.gameObject.name.Contains("Bullet"))
        {           
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else
            Destroy(other.gameObject);

        EnemyManager.Instance.enemyPool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
}
