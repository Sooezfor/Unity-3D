using System.Collections;
using TMPro;
using UnityEngine;

public class FPSGameManager : SingleTon<FPSGameManager>
{
    public enum GameState { Ready, Run, GameOver }
    public GameState gState = GameState.Ready;
    TextMeshProUGUI gameText;

    public GameObject gameLabel;

    FPSplayerMove player; 

    private void Start()
    {
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
}
