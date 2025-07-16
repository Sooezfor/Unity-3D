using System;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public GameObject ExplosionFactory;
    Vector3 dir;
    float speed = 5f;

    private void Start()
    {
        int ranValue = UnityEngine.Random.Range(0, 10); //시스템 랜덤과 유니티 랜덤 중 유니티랜덤 쓰겠다는 뜻

        if(ranValue <3) //30퍼만 인공지능 기능
        {
            GameObject target = GameObject.Find("Player"); //전체 검색하는 FInd 임. 스타트에서 써야함. 
            dir = target.transform.position - transform.position;

            dir.Normalize(); //알아서 연산하는 기능 
        }
        else // 70퍼        
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

       //책에는 sm.SetScore(sm.GetScore() + 1); 적힘. 아래는 풀어 적은 것
        var score = sm.GetScore() + 1;
        sm.SetScore(score);
      
        //파티클 생성 
        GameObject explosion = Instantiate(ExplosionFactory);
        explosion.transform.position = transform.position; //현재 위치에서 폭발 

        Destroy(other.gameObject);

        Destroy(gameObject);
    }
}
