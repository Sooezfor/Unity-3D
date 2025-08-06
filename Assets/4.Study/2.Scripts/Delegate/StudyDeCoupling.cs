using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float dmagae);
}
public class StudyDeCoupling : MonoBehaviour
{
    //�������̽� ����ؼ� ����� Idamageable �ִ��� Ȯ�� �� ������ ������ �����ϴ� ��Ŀ�ø�

    public class Player
    {
        public void AttackEnemy(IDamageable target, float damage) //�������̽� ���� ��� ���
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
