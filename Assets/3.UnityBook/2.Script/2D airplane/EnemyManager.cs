using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingleTon<EnemyManager>
{
    public int poolSize = 10;

    public Queue<GameObject> enemyPool;

    public Transform[] spawnPoints;
    public GameObject enemyFactory;

    float currentTime; //Ÿ�̸�

    public float createTime = 1f; //���� �ֱ�
    float minTime = 1;
    float maxTime = 5;


    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyPool = new Queue<GameObject>();

        for(int i = 0; i<poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            enemyPool.Enqueue(enemy);
            enemy.SetActive(false);
        }
    }
    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime) //Ÿ�̸Ӱ� ���� �����ֱ⸶�� ������ ��ġ�� �� ����

            if(enemyPool.Count>0)
            {            
                //Ÿ�̸� �ʱ�ȭ
                currentTime = 0;
                createTime = Random.Range(minTime, maxTime);

                GameObject enemy = enemyPool.Dequeue();

                int ranIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[ranIndex];

                enemy.transform.position = spawnPoint.position;
                enemy.SetActive(true);

            }
    }
}
