using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void Mydelegate(string str);
    public Mydelegate myDelegate;

    public Button button;

    private void Start()
    {
        //��ư�� 1���� ����� ����ϴ� ���
        button.onClick.AddListener(ButtonEvent);
        //button.onClick.AddListener(OnLog("Hello")); �Ű� ���� ������ ��� �Ұ���.        

        //�͸��Լ��� ���� ��� ����ϴ� ��� 
        button.onClick.AddListener(delegate
        {
            ButtonEvent();
            OnLog("Lambda");
        });
        //���ٽ����� 1���� ��� ��� 
        button.onClick.AddListener(() => OnLog("Hello"));

        //���ٽ����� ���� ��� ���, �Ű��������� ����
        button.onClick.AddListener(() =>
        {
            ButtonEvent();
            OnLog("Lambda");
        });
    }

    void ButtonEvent()
    {
        Debug.Log("Button Event");
    }

    void OnLog(string str)
    {
        Debug.Log("��ȣ");
    }
}
