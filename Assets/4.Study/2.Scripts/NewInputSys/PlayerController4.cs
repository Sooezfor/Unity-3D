using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    public class PlayerController4 : MonoBehaviour
    {
        private CharacterController cc;

        private Vector2 moveInput;
        public float speed = 5f;

        PlayerInput playerInput;
        InputAction moveAction;
        InputAction jumpAction;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions.FindAction("Player/Move");
            jumpAction = playerInput.actions.FindAction("Player/Jump"); 

            cc = GetComponent<CharacterController>();            
        }

        private void OnEnable()
        {
            jumpAction.started += Jump;
            moveAction.started += Move;

            jumpAction.performed += Jump;
        }

        private void OnDisable()
        {
            moveAction.Disable();
            moveAction.started -= Move;
            moveAction.canceled -= MoveCancel;

            jumpAction.Disable();
            jumpAction.performed -= Jump;
        }

        void Update()
        {
            var dir = new Vector3(moveInput.x, 0, moveInput.y);            

            cc.Move(dir * speed * Time.deltaTime);
        }

        public void Move(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        void MoveCancel(InputAction.CallbackContext context)
        {
            moveInput = Vector2.zero;
        }

        public void Jump(InputAction.CallbackContext context)
        {            
            Debug.Log("Jump");            
            // 점프 기능 실행
        }
    }

}
