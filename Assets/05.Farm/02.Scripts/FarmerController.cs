using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerController : MonoBehaviour
{
    Animator anim;
    CharacterController cc;
    Vector3 moveInput;

    bool isRun;
    float walkSpeed = 2f;
    float runSpeed = 5f;
    float turnSpeed = 10f;
    float currSpeed;

    Vector3 velocity;
    const float GRAVITY = -9.8f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }
    private void Update()
    {
        velocity.y += GRAVITY;
        var dir = moveInput * currSpeed + Vector3.up * velocity.y;

        cc.Move(dir * Time.deltaTime); 
        Turn();
        SetAnimation();      
    }
    private void OnMove(InputValue value)
    {
        var move = value.Get<Vector2>();
        moveInput = new Vector3(move.x, 0, move.y);
    }

    void Turn()
    {
        if(moveInput != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
                                                           //현재 회전 , 목표 회전, 비율 (속도)
        }
    }
    void OnRun(InputValue value)
    {
        isRun = value.isPressed;
    }

    void SetAnimation()
    {        
        float targetValue = 0f;

        if (moveInput != Vector3.zero) //이동키를 누른 경우
        {
            targetValue = isRun ? 1f : 0.5f; //뛰면 1. 안 뛰면 0.5 블렌드트리에 전달값 
            currSpeed = isRun ? runSpeed : walkSpeed; 

        }
        float animValue = anim.GetFloat("Move");
        animValue = Mathf.Lerp(animValue, targetValue, 10f * Time.deltaTime);

        anim.SetFloat("Move", animValue);
    }
}
