using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{
    CharacterController cc;

    Vector2 moveInput;
    public float speed = 5f;

    //public InputActionAsset inputActionAsset;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction interactionAction;
    InputAction attackAction;


    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move"); //������ �Ͱ� ����
        jumpAction = InputSystem.actions.FindAction("Jump"); //������ �Ͱ� ����
        interactionAction = InputSystem.actions.FindAction("Interaction"); //������ �Ͱ� ����
        attackAction = InputSystem.actions.FindAction("Attack"); //������ �Ͱ� ����

        cc = GetComponent<CharacterController>();
    }
    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if(moveInput != Vector2.zero)
        {
            Debug.Log("Move:" + moveAction.ReadValue<Vector2>());
            var dir = new Vector3(moveInput.x, 0, moveInput.y).normalized;

            cc.Move(dir * speed * Time.deltaTime);
        }
 
        if(jumpAction.WasPressedThisFrame())// �� �����ӿ��� ���ȴ��� Ȯ��
        {
            Debug.Log("jump:");
        }
        if (interactionAction.IsPressed()) //��ư ������ �ִ��� 
        {
            Debug.Log("interaction:");
        }
        if (attackAction.IsPressed())
        {
            Debug.Log("attack:");
        }

    }
}
