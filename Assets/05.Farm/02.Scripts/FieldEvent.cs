using Unity.Cinemachine;
using UnityEngine;

public class FieldEvent : MonoBehaviour
{

    [SerializeField] CinemachineClearShot clearShot;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.SetcamerState(CameraState.Field);
            GameManager.Instance.ui.ActivateFieldUI(true);


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetcamerState(CameraState.Outside);
            GameManager.Instance.ui.ActivateFieldUI(false);
            //GameManager.Instance.field.fieldState = FieldManager.FieldState.None;

        }

    }
}
