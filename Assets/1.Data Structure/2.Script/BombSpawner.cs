using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;

    public int rangeX = 5;
    public int rangeZ = 5;

    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            RespwanBomb();
        }
    }
    void RespwanBomb()
    {
        float ranX = Random.Range(-rangeX, rangeX + 1); //+1 ���ִ� ������ ������������ ���������� ���� �� �ϱ� ������ 5���� ���Խ�Ű�� ���� +1 
        float ranZ = Random.Range(-rangeZ, rangeZ + 1);

        Vector3 ranPos = new Vector3(ranX, 10f, ranZ);

        Instantiate(bombPrefab, ranPos, Quaternion.identity);
    }
}
