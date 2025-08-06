using UnityEngine;

public class MoveState : IState
{
    public void StateEnter(MonoBehaviour mono)
    {
        Debug.Log("Enter Move");
    }

    public void StateUpdate(MonoBehaviour mono)
    {
        Debug.Log("Update Move");
    }


    public void StateExit(MonoBehaviour mono)
    {
        Debug.Log("Exit Move");
    }
}
