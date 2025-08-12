using Unity.Cinemachine;
using UnityEngine;

public class FieldEvent : MonoBehaviour
{
    [SerializeField] CinemachineClearShot clearShot;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            GameManager.Instance.SetcamerState(CameraState.Field);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.Instance.SetcamerState(CameraState.Outside);
    }
}
