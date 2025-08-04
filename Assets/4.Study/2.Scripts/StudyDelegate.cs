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
        onTimerStart.Invoke(); //Ÿ�̸� ������ �� �Լ�ȣ��
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
            onTimerEnd.Invoke(); //Ÿ�̸� ������ �� �Լ� ȣ��
        }
    }
    void StartEvent()
    {
        Debug.Log("Ÿ�̸� ����");
    }
    void EndEvent()
    {
        Debug.Log("Ÿ�̸� ����");
    }

}
