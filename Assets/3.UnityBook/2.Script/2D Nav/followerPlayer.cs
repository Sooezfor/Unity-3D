using UnityEngine;
using UnityEngine.AI;

public class followerPlayer : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(player.position);
    }
}
