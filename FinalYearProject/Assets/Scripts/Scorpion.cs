using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Scorpion : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask isGround, isPlayer;

    // Patrolling
    public Vector3 walkPoint;
    public float walkPointRange;
    bool walkPointSet;

    public float sightRange;
    public bool playerInSightRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check if player is in sight
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);

        if (!playerInSightRange)
        {
            Patrolling();
        }

        if (playerInSightRange)
        {
            ChasePlayer();
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        // If distance is less than 1, then walkpoint is reached
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        // Return a random value depending how high walk point range is
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);


        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Checks if point is on the ground, so object doesn't walk off the map
        if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }


}
