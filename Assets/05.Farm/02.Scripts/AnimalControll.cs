using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System;
using Random = UnityEngine.Random;

public class AnimalControll : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    [SerializeField] float wanderRadius = 15f;
    float minWaitTime = 1f;
    float maxWaitTime = 5f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }
    IEnumerator Start()
    {
        while(true) //������ ��� ���ƴٳ�� �ϴϱ�
        {
            SetRandomDestination(); //���� ������ ����
            anim.SetBool("isWalk", true);

            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

            anim.SetBool("isWalk", false);
            float idleTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(idleTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {            
            AnimalEvent.failAction?.Invoke();
            Debug.Log("���� ���ϱ� ����");
        }
    }
    void SetRandomDestination()
    {
        var randomDir = Random.insideUnitSphere * wanderRadius;
        randomDir += transform.position;

        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomDir, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

}
