using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    private int currScore;
    private int bestScore;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0); //저장된 점수 불러오기, 뒤에 오는 0은 default 값임.

        bestScoreUI.text = "최고 점수 :" + bestScore;
    }

    public void SetScore(int value)
    {
        currScore = value;

        currentScoreUI.text = "현재 점수 : " + currScore;

        if (currScore > bestScore)
        {
            bestScore = currScore;
            bestScoreUI.text = "최고점수 :" + bestScore;

            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

   public int GetScore()
    {
        return currScore;
    }
}
