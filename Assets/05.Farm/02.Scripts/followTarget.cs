using UnityEngine;

public class followTarget : MonoBehaviour
{
    public Transform target;
    bool isTracking = false; 

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        transform.position = target.position;
    }
}
