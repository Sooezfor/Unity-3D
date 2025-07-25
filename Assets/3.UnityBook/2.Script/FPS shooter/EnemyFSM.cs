using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState { Idle, Move, Attack, Return, Damaged, Die }
    EnemyState m_State;

    Transform player;
    CharacterController cc;
    Animator anim;
    NavMeshAgent smith;

    public float findDistance = 8f; //Ž�� �Ÿ� 
    public float attackDistance = 3f; //���� ���� �Ÿ�
    public float moveSpeed = 5f; //�̵� �ӵ�
    float currentTime = 0f; //Ÿ�̸� 
    float attackDelay = 2f; //������

    public int attackPower = 3;
    public int hp = 15;
    int maxHp = 15;
    public Slider hpSlider;

    Vector3 originPos;
    Quaternion originRot;
    public float moveDistance = 20f; //ó�� ��ġ�������� 20���ͱ��� �Ѿư� �� �մ� 

    private void Start()
    {
        m_State = EnemyState.Idle;
        cc = GetComponent<CharacterController>();
        player = GameObject.Find("Player").transform;
        originPos = transform.position; //���� ��ġ�� ������ �����
        originRot = transform.rotation;
        anim = transform.GetComponentInChildren<Animator>();
        smith = GetComponent<NavMeshAgent>();
       
    }

    private void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move(); 
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;           
        }

        hpSlider.value = (float)hp / (float)maxHp;
    }

    void Idle()
    {
        if(Vector3.Distance(transform.position, player.position) < findDistance)
        {
            anim.SetTrigger("IdleToMove"); //move �ִϸ��̼� ���� Ű�� ���� 
            m_State = EnemyState.Move;
            Debug.Log("���� ��ȯ : Idle -> Move");
        }                    
    }

    private void Move()
    {
        if(Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
            Debug.Log("���� ��ȯ: Move -> Return");
            
        }                
        else if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            smith.isStopped = true; //���߱�
            smith.ResetPath(); //����

            smith.stoppingDistance = attackDistance;
            smith.SetDestination(player.position); //������ ����
        }
        else
        {
            currentTime = attackDelay;
            anim.SetTrigger("MoveToAttackDelay");
            m_State = EnemyState.Attack;
            Debug.Log("���� ��ȯ : Move -> At tack");
        }
    }

    void Attack()
    {
        if(Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime; //Ÿ�̸�ó�� �����
            if(currentTime > attackDelay)
            {
                currentTime = 0f; //��Ȱ�� �ϱ� ���� �ʱ�ȭ
                anim.SetTrigger("StartAttack");
                Debug.Log("����");
            }
        }
        else
        {
            currentTime = 0f;
            m_State = EnemyState.Move;
            anim.SetTrigger("AttackToMove");
            Debug.Log("���� ��ȯ : Attack -> Move");
        }
    }

    public void AttackAction()
    {
         player.GetComponent<FPSplayerMove>().DamageAction(attackPower);
    }
    void Return()
    {
        if(Vector3.Distance(transform.position, originPos) > 0.1f) //���� ��ġ�� �ƴ� ��� ���� ��ġ�� �̵�
        {
            smith.SetDestination(originPos);
            smith.stoppingDistance = 0;
        }
        else //���� ��ġ�� ������ ���
        {
            smith.isStopped = true;
            smith.ResetPath();

            transform.position = originPos;
            transform.rotation = originRot;
            hp = 15; //�� ȸ��
            anim.SetTrigger("MoveToIdle");
            m_State = EnemyState.Idle;
            Debug.Log("���� ��ȯ : Return - > idle");
        }
    }
    public void HitEnemy(int hitPower)
    {
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return)
            return;
        
        hp -= hitPower;

        smith.isStopped = true;
        smith.ResetPath(); 

        if (hp > 0) //������ �޾Ҵµ� ��Ҵٸ� 
        {            
            anim.SetTrigger("Damaged");
            m_State = EnemyState.Damaged;
            Debug.Log("���� ��ȯ : Any State -> Damaged");
            Damaged();                
        }
        else //���� �ް� ����
        {
            m_State = EnemyState.Die;
            anim.SetTrigger("Die");
            Debug.Log("���� ��ȯ : Any State -> Die ");
            Die();
        }
    }
    void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1f);

        m_State = EnemyState.Move;
        Debug.Log("���� ��ȯ: Damaged -> Move");
    }
    void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false; //�������� �ʵ���

        yield return new WaitForSeconds(2f);
        Debug.Log("�Ҹ�");
        Destroy(gameObject);
    }
}
