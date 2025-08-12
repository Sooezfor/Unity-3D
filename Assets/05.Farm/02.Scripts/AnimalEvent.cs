using Unity.Cinemachine;
using UnityEngine;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] CinemachineClearShot clearShot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.Instance.SetcamerState(CameraState.Animal);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            GameManager.Instance.SetcamerState(CameraState.Outside);
    }
}
