using UnityEngine;

public interface IState 
{
    void StateEnter(MonoBehaviour mono);
    void StateUpdate(MonoBehaviour mono);
    void StateExit(MonoBehaviour mono);
}
