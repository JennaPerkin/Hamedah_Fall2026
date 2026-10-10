using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public LayerMask isGround, isPlayer;

    [Header("Patroling")]
    public Vector3 walkPoint;
    bool isWalkPointSet;
    public float walkPointRange;

    [Header("States")]
    public float sightRange;
    bool isPlayerInSightRange;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        if (isPlayerInSightRange) Chasing();
        else Patrolling();
    }

    void Patrolling()
    {
        if (!isWalkPointSet) SearchWalkPoint();
        else agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 2f) isWalkPointSet = false;
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, 
            transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround)) isWalkPointSet = true;

    }

    void Chasing()
    {
        agent.SetDestination(player.position);
    }
}
