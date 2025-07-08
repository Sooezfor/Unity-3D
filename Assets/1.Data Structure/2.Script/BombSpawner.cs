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
        float ranX = Random.Range(-rangeX, rangeX + 1); //+1 해주는 이유는 랜덤레인지가 마지막값은 포함 안 하기 때문에 5까지 포함시키기 위해 +1 
        float ranZ = Random.Range(-rangeZ, rangeZ + 1);

        Vector3 ranPos = new Vector3(ranX, 10f, ranZ);

        Instantiate(bombPrefab, ranPos, Quaternion.identity);
    }
}
