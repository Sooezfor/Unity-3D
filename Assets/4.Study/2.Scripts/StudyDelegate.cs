using UnityEngine;

public class StudyDelegate : MonoBehaviour
{
    public delegate void TimerStart();
    public TimerStart onTimerStart;

    public delegate void TimerEnd();
    public TimerEnd onTimerEnd;

    float timer = 5f;
    bool isTimer = true;

    private void OnEnable()
    {
        onTimerStart += StartEvent;
        onTimerEnd += EndEvent;
    }

    private void Start()
    {
        onTimerStart.Invoke(); //타이머 시작할 때 함수호출
    }
    private void OnDisable()
    {
        onTimerStart -= StartEvent;
        onTimerEnd -= EndEvent; 
    }

    private void Update()
    {
        if (!isTimer)
            return;

        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            isTimer = false;
            onTimerEnd.Invoke(); //타이머 끝났을 때 함수 호출
        }
    }
    void StartEvent()
    {
        Debug.Log("타이머 시작");
    }
    void EndEvent()
    {
        Debug.Log("타이머 종료");
    }

}
