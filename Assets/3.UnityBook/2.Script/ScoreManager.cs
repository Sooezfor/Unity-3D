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
        bestScore = PlayerPrefs.GetInt("BestScore", 0); //����� ���� �ҷ�����, �ڿ� ���� 0�� default ����.

        bestScoreUI.text = "�ְ� ���� :" + bestScore;
    }

    public void SetScore(int value)
    {
        currScore = value;

        currentScoreUI.text = "���� ���� : " + currScore;

        if (currScore > bestScore)
        {
            bestScore = currScore;
            bestScoreUI.text = "�ְ����� :" + bestScore;

            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }

   public int GetScore()
    {
        return currScore;
    }
}
