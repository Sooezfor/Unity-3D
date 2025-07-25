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
        gameText.color = new Color32(255, 185, 0, 255); //주황색

        player = GameObject.Find("Player").GetComponent<FPSplayerMove>();

        StartCoroutine(ReadyToStart());
    }

    private void Update()
    {
        if(player.hp <= 0)
        {
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f); //아무런 애니메이션 안되게끔
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
        Time.timeScale = 0f; //퍼즈 잡힘. 플레이 실행이 멈춘다.  UI 동작은 안 멈춤
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
        //로딩씬 가져오기
    }

    public void QuitGame()
    {
        //Destroy(gameObject); 

        Application.Quit(); //게임 끄기
    }
}
