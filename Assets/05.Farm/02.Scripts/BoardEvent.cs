using UnityEngine;

public class BoardEvent : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            {
                GameManager.Instance.SetcamerState(CameraState.Board);
            }        
    }

  
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {        
            GameManager.Instance.SetcamerState(CameraState.House);  
        }
    }      

}
