using UnityEngine;

public class AttackState : IState
{

    public void StateEnter(MonoBehaviour mono)
    {
        Debug.Log("Enter Attack");
    }

    public void StateUpdate(MonoBehaviour mono)
    {
        Debug.Log("Update Attack");        
    }


    public void StateExit(MonoBehaviour mono)
    {
        Debug.Log("Exit Attack");
    }


}
