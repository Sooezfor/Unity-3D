using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onUnityEvent;

    private void Start()
    {
        onUnityEvent.AddListener(delegate
        {
            Debug.Log("Hello");
            Debug.Log("Unity");
            Debug.Log("World");
            MethodA();
            MethodB();

            PrintLog("Hello Sooez");
        });
           
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            onUnityEvent?.Invoke();
    }
    void MethodA()
    {
        Debug.Log("Method A");
    }

    void MethodB()
    {
        Debug.Log("Method B");
    }

    void PrintLog(string msg)
    {
        Debug.Log(msg);
    }
}
