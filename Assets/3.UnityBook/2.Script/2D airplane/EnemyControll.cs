using System;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public GameObject ExplosionFactory;
    Vector3 dir;
    float speed = 5f;

    private void OnEnable()
    {
        int ranValue = UnityEngine.Random.Range(0, 10); //시스템 랜덤과 유니티 랜덤 중 유니티랜덤 쓰겠다는 뜻

        if(ranValue < 7) //70퍼만 인공지능 기능
        {
            GameObject target = GameObject.Find("Player"); //전체 검색하는 FInd 임. 스타트에서 써야함. 
            dir = target.transform.position - transform.position;
            dir.Normalize(); //알아서 연산하는 기능 
        }
        else // 30퍼        
            dir = Vector3.down;        
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        ScoreManager.Instance.Score++; // 최종 줄임 값을 +1 해서 프로퍼티로 넘김
      
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
