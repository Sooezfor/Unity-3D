using UnityEngine;

namespace Pattern.Command
{
    public class Player2 : MonoBehaviour
    {
        public void Attack()
        {
            Debug.Log("Attack");
        }
        public void AttackCancel()
        {
            Debug.Log("Attack Canecel");
        }
        public void JumpCancel()
        {
            Debug.Log("JumpCancel");
        }
        public void Jump()
        {
            Debug.Log("Jump");
        }
        public void UseSkill(string skillName)
        {
            Debug.Log($"Use Skill : {skillName}");
        }

        public void UseSkillCancel(string skillName)
        {
            Debug.Log($"Use Skill Cancel : {skillName}");
        }
    }

}
