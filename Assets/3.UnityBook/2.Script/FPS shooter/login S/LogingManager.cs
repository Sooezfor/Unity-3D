using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogingManager : MonoBehaviour
{
    public TMP_InputField id;
    public TMP_InputField password;

    //public TextMeshPro notify;
    public TextMeshProUGUI notify;

    private void Start()
    {
        notify.text = "";
    }

    public void SaveUserData()
    {
        if(!CheckInput(id.text, password.text)) //false 값이라면         
            return;

        if (!PlayerPrefs.HasKey(id.text)) //현재 저장된 데이터 중에 동일한 id 있는지 확인
        {
            PlayerPrefs.SetString(id.text, password.text); //유저 아이디 비번 저장

            notify.text = "아이디 생성이 완료되었습니다.";
        }
        else// 입력한 아이디(키값)이 존재한다면 
        {
            notify.text = "이미 존재하는 아이디입니다.";
        }
    }

    public void CheckUserData()
    {
        if (!CheckInput(id.text, password.text)) //false 값이라면         
            return;

        string pass = PlayerPrefs.GetString(id.text); //아이디(key)에 저장된 패스워드 (value) 가져옴

        if(password.text == pass)        
            SceneManager.LoadScene(1);        
        else        
            notify.text = "입력하신 아이디와 패스워드가 일치하지 않습니다.";        
    }

    bool CheckInput(string id, string pwd)
    {
        if (id == "" || pwd == "")
        {
            notify.text = " 아이디 또는 패스워드를 입력해주세요.";
            return false;
        }
        else
            return true;
    }
}
