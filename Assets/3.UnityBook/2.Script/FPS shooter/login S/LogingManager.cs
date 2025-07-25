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
        if(!CheckInput(id.text, password.text)) //false ���̶��         
            return;

        if (!PlayerPrefs.HasKey(id.text)) //���� ����� ������ �߿� ������ id �ִ��� Ȯ��
        {
            PlayerPrefs.SetString(id.text, password.text); //���� ���̵� ��� ����

            notify.text = "���̵� ������ �Ϸ�Ǿ����ϴ�.";
        }
        else// �Է��� ���̵�(Ű��)�� �����Ѵٸ� 
        {
            notify.text = "�̹� �����ϴ� ���̵��Դϴ�.";
        }
    }

    public void CheckUserData()
    {
        if (!CheckInput(id.text, password.text)) //false ���̶��         
            return;

        string pass = PlayerPrefs.GetString(id.text); //���̵�(key)�� ����� �н����� (value) ������

        if(password.text == pass)        
            SceneManager.LoadScene(1);        
        else        
            notify.text = "�Է��Ͻ� ���̵�� �н����尡 ��ġ���� �ʽ��ϴ�.";        
    }

    bool CheckInput(string id, string pwd)
    {
        if (id == "" || pwd == "")
        {
            notify.text = " ���̵� �Ǵ� �н����带 �Է����ּ���.";
            return false;
        }
        else
            return true;
    }
}
