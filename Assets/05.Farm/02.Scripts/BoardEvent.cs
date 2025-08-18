using UnityEngine;

public class BoardEvent : MonoBehaviour
{
    [SerializeField] GameObject boardUI;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            {
                boardUI.SetActive(true);
                SingleBoard_Controller.startAction?.Invoke();
                GameManager.Instance.SetcamerState(CameraState.Board);
            }        
    }

  
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boardUI.SetActive(false);

            GameManager.Instance.SetcamerState(CameraState.House);  
        }
    }      

}
