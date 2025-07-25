using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSGameManager : SingleTon<FPSGameManager>
{
    public enum GameState { Ready, Run, Pause, GameOver }
    public GameState gState = GameState.Ready;
    TextMeshProUGUI gameText;
   
    public GameObject gameOption; 
    public GameObject gameLabel;

    FPSplayerMove player; 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        gameText = gameLabel.GetComponent<TextMeshProUGUI>();

        gameText.text = "Ready...";
        gameText.color = new Color32(255, 185, 0, 255); //��Ȳ��

        player = GameObject.Find("Player").GetComponent<FPSplayerMove>();

        StartCoroutine(ReadyToStart());
    }

    private void Update()
    {
        if(player.hp <= 0)
        {
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f); //�ƹ��� �ִϸ��̼� �ȵǰԲ�
            gameLabel.SetActive(true);
            gameText.text = "GAME OVER";

            Transform buttons = gameText.transform.GetChild(0);
            buttons.gameObject.SetActive(true);

            gameText.color = new Color32(255, 0, 0, 255);

            gState = GameState.GameOver;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);
        gameText.text = "Go!";
        gameText.color = new Color32(61, 255, 0, 255);

        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        gState = GameState.Run;

    }

    public void OpenOptionWindow()
    {
        gameOption.SetActive(true);
        Time.timeScale = 0f; //���� ����. �÷��� ������ �����.  UI ������ �� ����
        gState = GameState.Pause;
    }
    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
        Time.timeScale = 1f;
        gState = GameState.Run; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;        
        SceneManager.LoadScene(1);
        //�ε��� ��������
    }

    public void QuitGame()
    {
        //Destroy(gameObject); 

        Application.Quit(); //���� ����
    }
}
