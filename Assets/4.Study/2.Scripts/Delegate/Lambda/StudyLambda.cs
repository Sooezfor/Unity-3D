using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void Mydelegate(string str);
    public Mydelegate myDelegate;

    public Button button;

    private void Start()
    {
        //버튼에 1개의 기능을 등록하는 방법
        button.onClick.AddListener(ButtonEvent);
        //button.onClick.AddListener(OnLog("Hello")); 매개 변수 있으면 사용 불가능.        

        //익명함수로 여러 기능 등록하는 방법 
        button.onClick.AddListener(delegate
        {
            ButtonEvent();
            OnLog("Lambda");
        });
        //람다식으로 1개의 기능 등록 
        button.onClick.AddListener(() => OnLog("Hello"));

        //람다식으로 여러 기능 등록, 매개변수까지 가능
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
        Debug.Log("야호");
    }
}
