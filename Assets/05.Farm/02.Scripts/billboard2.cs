using UnityEngine;

public class billboard2 : MonoBehaviour
{
    Transform mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCamera.transform);
    }
}
