using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float dmagae);
}
public class StudyDeCoupling : MonoBehaviour
{
    //인터페이스 사용해서 대상이 Idamageable 있는지 확인 후 있으면 데미지 적용하는 디커플링

    public class Player
    {
        public void AttackEnemy(IDamageable target, float damage) //인터페이스 가진 대상 기반
        {
            target.TakeDamage(damage);
        }
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        public float hp = 10;
        public void TakeDamage(float damage)
        {
            hp -= damage;
            
        }
    }
}
