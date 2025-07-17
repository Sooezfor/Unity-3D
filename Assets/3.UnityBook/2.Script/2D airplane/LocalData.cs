using UnityEngine;

public class LocalData : MonoBehaviour
{
    int score;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            score++;
            
            PlayerPrefs.SetInt("Score", score); //���õ����� ����. Ű,��� ����. 
            int loadScore = PlayerPrefs.GetInt("Score"); //������ �ҷ�����

            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetFloat("Volume", 0.5f);
            PlayerPrefs.GetString("UserName", "John");

            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Volume");
            PlayerPrefs.DeleteKey("UserName");

            PlayerPrefs.DeleteAll(); //�� ����� 

            PlayerPrefs.Save(); // ����� �� �ڵ� ����
        }
    }
}
