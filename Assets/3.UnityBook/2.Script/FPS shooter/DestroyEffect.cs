using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    float destroyTime = 2.6f;
    float currentTime = 0f;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
