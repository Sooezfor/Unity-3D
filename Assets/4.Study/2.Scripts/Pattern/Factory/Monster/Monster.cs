using UnityEngine;

namespace Pattern.Factory
{
    public class Monster : MonoBehaviour
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Attack { get; protected set; }

        protected virtual void Initialize(string name, int health, int attack)
        { //생성자 역할 하는 함수 수동으로 만들음 
            Name = name;
            Health = health;
            Attack = attack;
            Debug.Log($"{Name} / {Health} / {Attack} 생성");
        }
    }

}
