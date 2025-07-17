using UnityEngine;

public class LocalData : MonoBehaviour
{
    int score;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            score++;
            
            PlayerPrefs.SetInt("Score", score); //로컬데이터 저장. 키,밸류 값임. 
            int loadScore = PlayerPrefs.GetInt("Score"); //데이터 불러오기

            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetFloat("Volume", 0.5f);
            PlayerPrefs.GetString("UserName", "John");

            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Volume");
            PlayerPrefs.DeleteKey("UserName");

            PlayerPrefs.DeleteAll(); //다 지우기 

            PlayerPrefs.Save(); // 종료될 때 자동 실행
        }
    }
}
