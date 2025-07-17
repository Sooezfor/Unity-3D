using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : SingleTon<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;

    public Queue<GameObject> bulletObjectPool;

    void Start()
    {
        bulletObjectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            bulletObjectPool.Enqueue(bullet);
            bullet.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;               
            }
        }
    }
}