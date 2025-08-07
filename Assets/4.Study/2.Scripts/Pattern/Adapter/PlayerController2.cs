using UnityEngine;

namespace Pattern.Adapter
{
    public class PlayerController2 : MonoBehaviour
    {
        public GameObject player;

        ICharacter character;

        private void Start()
        {
            character = player.GetComponent<ICharacter>();

            character.Move(Vector3.forward);
            character.Attack();
        }
    }
}

