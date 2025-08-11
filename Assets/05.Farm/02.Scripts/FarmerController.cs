using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerController : MonoBehaviour
{
    Animator anim;
    PlayerInput playerInput;
    CharacterController cc;
    Vector3 moveInput;
    float moveSpeed = 2f;
    float turnSpeed = 10f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        cc.Move(moveInput * moveSpeed * Time.deltaTime);
        Turn();
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
                                                           //���� ȸ�� , ��ǥ ȸ��, ���� (�ӵ�)
        }
    }
}
