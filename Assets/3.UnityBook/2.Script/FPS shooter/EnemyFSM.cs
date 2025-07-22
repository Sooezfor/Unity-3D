using System.Collections;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    enum EnemyState { Idle, Move, Attack, Return, Damaged, Die }
    EnemyState m_State;

    Transform player;
    CharacterController cc;
    Animator anim;

    public float findDistance = 8f; //탐지 거리 
    public float attackDistance = 3f; //공격 가능 거리
    public float moveSpeed = 5f; //이동 속도
    float currentTime = 0f; //타이머 
    float attackDelay = 2f; //딜레이

    public int attackPower = 3;
    public int hp = 15;
    int maxHp = 15;
    public Slider hpSlider;

    Vector3 originPos;
    public float moveDistance = 20f; //처음 위치에서부터 20미터까지 쫓아갈 수 잇다 

    private void Start()
    {
        m_State = EnemyState.Idle;
        cc = GetComponent<CharacterController>();
        player = GameObject.Find("Player").transform;
        originPos = transform.position; //생성 위치를 오리진 포즈로
        anim = transform.GetComponentInChildren<Animator>(); 

        Cursor.visible = false; //커서 안 보이기
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
            anim.SetTrigger("IdleToMove"); //move 애니메이션 실행 키값 전달 
            m_State = EnemyState.Move;
            Debug.Log("상태 전환 : Idle -> Move");
        }                    
    }

    private void Move()
    {
        if(Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
            Debug.Log("상태 전환: Move -> Return");
            
        }                
        else if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized; //특정 타겟과의 방향과 이동거리까지 구하는 방법
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir; //이동 방향을 정면으로 초기화            
        }
        else
        {
            currentTime = attackDelay;
            anim.SetTrigger("MoveToAttackDelay");
            m_State = EnemyState.Attack;
            Debug.Log("상태 전환 : Move -> At tack");
        }
    }

    void Attack()
    {
        if(Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime; //타이머처럼 만들기
            if(currentTime > attackDelay)
            {
                currentTime = 0f; //재활용 하기 위해 초기화
                anim.SetTrigger("StartAttack");
                Debug.Log("공격");
            }
        }
        else
        {
            currentTime = 0f;
            m_State = EnemyState.Move;
            anim.SetTrigger("AttackToMove");
            Debug.Log("상태 전환 : Attack -> Move");
        }
    }

    public void AttackAction()
    {
         player.GetComponent<FPSplayerMove>().DamageAction(attackPower);
    }

    void Return()
    {
        if(Vector3.Distance(transform.position, originPos) > 0.1f) //원래 위치가 아닌 경우 원래 위치로 이동
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;

        }
        else //원래 위치로 도착한 경우
        {
            transform.position = originPos;
            hp = 15; //피 회복
            anim.SetTrigger("MoveToIdle");
            m_State = EnemyState.Idle;
            Debug.Log("상태 전환 : Return - > idle");
        }
    }
    public void HitEnemy(int hitPower)
    {
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return)
            return;
        
        hp -= hitPower;

        if (hp > 0) //공격을 받았는데 살았다면 
        {            
            anim.SetTrigger("Damaged");
            m_State = EnemyState.Damaged;
            Debug.Log("상태 전환 : Any State -> Damaged");
            Damaged();                
        }
        else //공격 받고 죽음
        {
            m_State = EnemyState.Die;
            anim.SetTrigger("Die");
            Debug.Log("상태 전환 : Any State -> Die ");
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
        Debug.Log("상태 전환: Damaged -> Move");
    }

    void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false; //움직이지 않도록

        yield return new WaitForSeconds(2f);
        Debug.Log("소멸");
        Destroy(gameObject);
    }

}
