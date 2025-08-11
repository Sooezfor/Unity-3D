using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    public class PlayerController5 : MonoBehaviour
    {        
        CharacterController cc;

        public float speed = 5f;

        Vector2 moveInput;
        private void Start()
        {
            cc = GetComponent<CharacterController>();
        }
        private void Update()
        {
            var dir = new Vector3(moveInput.x, 0, moveInput.y);
            cc.Move(dir * speed * Time.deltaTime);
        }

        private void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

        void OnJump(InputValue value)
        {
            bool isJump = value.isPressed;
            Debug.Log(isJump);
        }
        void OnInteraction(InputValue value)
        {                        
            Debug.Log(value.isPressed);
        }
        void OnAttack(InputValue value)
        {
            Debug.Log("OnAttack");
        }

    }

}
