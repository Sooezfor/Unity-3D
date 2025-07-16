using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime; //Ÿ�̸�
    public float createTime = 1f; //���� �ֱ�
    float minTime = 1;
    float maxTime = 5;

    public GameObject enemyFactory;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime); 
    }
    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime) //Ÿ�̸Ӱ� �����ֱ⸦ �Ѿ��ٸ� 
        {
            //����
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;

            //Ÿ�̸� �ʱ�ȭ
            currentTime = 0; 
        }
    }
}
