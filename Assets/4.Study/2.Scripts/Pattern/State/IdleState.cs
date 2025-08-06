using UnityEngine;

public class IdleState : IState
{
    bool isInit = false;
    public void StateEnter(MonoBehaviour mono)
    {
        Debug.Log("Enter Idle");
    }

    public void StateUpdate(MonoBehaviour mono)
    {
        Debug.Log("Update Idle");
    }


    public void StateExit(MonoBehaviour mono)
    {
        Debug.Log("Exit Idle");
    }

}
