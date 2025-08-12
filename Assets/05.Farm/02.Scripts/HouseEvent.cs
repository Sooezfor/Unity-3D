using Unity.Cinemachine;
using UnityEngine;

public class HouseEvent : MonoBehaviour
{
    [SerializeField] CinemachineClearShot clearShot;
    [SerializeField] GameObject houseTop;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseTop.SetActive(false);
            GameManager.Instance.SetcamerState(CameraState.House);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseTop.SetActive(true);
            GameManager.Instance.SetcamerState(CameraState.Outside);
        }
    }
}
