using Unity.Cinemachine;
using UnityEngine;

public class FieldEvent : MonoBehaviour
{
    [SerializeField] CinemachineClearShot clearShot;
    private void OnTriggerEnter(Collider other)
    {
        clearShot.ChildCameras[0].Priority = 1;
        clearShot.ChildCameras[1].Priority = 10;

    }

    private void OnTriggerExit(Collider other)
    {
        clearShot.ChildCameras[0].Priority = 10;
        clearShot.ChildCameras[1].Priority = 1;
    }
}
