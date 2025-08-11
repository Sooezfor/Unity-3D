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
        moveAction = InputSystem.actions.FindAction("Move"); //만들어둔 것과 연결
        jumpAction = InputSystem.actions.FindAction("Jump"); //만들어둔 것과 연결
        interactionAction = InputSystem.actions.FindAction("Interaction"); //만들어둔 것과 연결
        attackAction = InputSystem.actions.FindAction("Attack"); //만들어둔 것과 연결

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
 
        if(jumpAction.WasPressedThisFrame())// 이 프레임에서 눌렸는지 확인
        {
            Debug.Log("jump:");
        }
        if (interactionAction.IsPressed()) //버튼 누르고 있는지 
        {
            Debug.Log("interaction:");
        }
        if (attackAction.IsPressed())
        {
            Debug.Log("attack:");
        }

    }
}
