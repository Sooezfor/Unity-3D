using UnityEngine;

namespace Pattern
{
    public class ChracterMove : MonoBehaviour
    {
        IMovement movement;

        private void Start()
        {
            movement = new MoveWalk(3f);
        }
        private void Update()
        {
            Move();
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                movement = new MoveWalk(3f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                movement = new MoveRun(8f);
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                movement = new MoveFly(1.5f);
            }
        }

        void Move()
        {
            movement.Move(transform);
        }
        
    }
    

}
