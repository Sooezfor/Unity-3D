using UnityEngine;

public class StudyState : MonoBehaviour
{
    public IState state;

    IState idleState = new IdleState();
    IState moveState = new MoveState();
    IState attackState = new AttackState();

    private void Awake()
    {
        state = idleState;
    }

    private void Start()
    {
        state.StateEnter(this);
    }

    private void OnDestroy()
    {
        state.StateExit(this); 
    }
    private void Update()
    {
        state?.StateUpdate(this);

        #region 기능테스트

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(idleState);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(moveState);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(attackState);

        }
        #endregion
    }

    public void SetState(IState newState)
    {
        if(state != newState)
        {
            //상태 변경 전
            state.StateExit(this);

            state = newState; //상태 변경 

            //상태 변경 후 
            state.StateEnter(this);
        }
    }
}