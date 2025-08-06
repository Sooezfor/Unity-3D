
using UnityEngine;

public class StudyState : MonoBehaviour
{
    public IState state = new IdleState();

    private void Start()
    {
        state.StateEnter();
    }

    private void OnDestroy()
    {
        state.StateExit(); 
    }
    private void Update()
    {
        state?.StateUpdate();

        #region 기능테스트

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(new IdleState());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(new MoveState());

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(new AttackState());

        }
        #endregion
    }

    public void SetState(IState newState)
    {
        if(state != newState)
        {
            //상태 변경 전
            state.StateExit();

            state = newState; //상태 변경 

            //상태 변경 후 
            state.StateEnter();
        }


    }


}