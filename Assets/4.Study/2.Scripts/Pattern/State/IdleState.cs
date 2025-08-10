using System.Collections;
using UnityEngine;

public class IdleState : IState
{    
    public void StateEnter(MonoBehaviour mono)
    {
        Debug.Log("Enter Idle");
        mono.StartCoroutine(MethodA());
    }
    public void StateUpdate(MonoBehaviour mono)
    {
        Debug.Log("Update Idle");
    }

    public void StateExit(MonoBehaviour mono)
    {
        Debug.Log("Exit Idle");
    }

    IEnumerator MethodA()
    {
        yield return null;
    }
}
