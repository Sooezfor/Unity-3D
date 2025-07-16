using System;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public GameObject ExplosionFactory;
    Vector3 dir;
    float speed = 5f;

    private void Start()
    {
        int ranValue = UnityEngine.Random.Range(0, 10); //�ý��� ������ ����Ƽ ���� �� ����Ƽ���� ���ڴٴ� ��

        if(ranValue <3) //30�۸� �ΰ����� ���
        {
            GameObject target = GameObject.Find("Player"); //��ü �˻��ϴ� FInd ��. ��ŸƮ���� �����. 
            dir = target.transform.position - transform.position;

            dir.Normalize(); //�˾Ƽ� �����ϴ� ��� 
        }
        else // 70��        
            dir = Vector3.down;        
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

       //å���� sm.SetScore(sm.GetScore() + 1); ����. �Ʒ��� Ǯ�� ���� ��
        var score = sm.GetScore() + 1;
        sm.SetScore(score);
      
        //��ƼŬ ���� 
        GameObject explosion = Instantiate(ExplosionFactory);
        explosion.transform.position = transform.position; //���� ��ġ���� ���� 

        Destroy(other.gameObject);

        Destroy(gameObject);
    }
}
