using System;
using UnityEngine;

public class StudyAction : MonoBehaviour
{
    public event Action action;
    public Action<string> action2;
    public Action<string, int, float, bool> action3;

    private void Start()
    {
        action += () => Debug.Log("Action"); 
        action?.Invoke();

        action2 += msg => Debug.Log(msg);
        action2?.Invoke("Hello Unity");

        action3 += ((name, hp, mp, bool1) =>
        {
            Debug.Log(name);
            Debug.Log(hp);
            Debug.Log(mp);
            Debug.Log(bool1);
        });
        action3?.Invoke("mac", 10, 2f, true);

    }
}
