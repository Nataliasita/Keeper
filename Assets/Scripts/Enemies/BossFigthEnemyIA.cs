using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossFigthEnemyIA : MonoBehaviour
{
    
    [Header("Enemy Elements")]
    public BossEnemyStats enemyStats;
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float OfffsetAttackTime;

    [Header("Patrolling")]
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    [Header("Attacking")]
    //public Transform FireStart;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject DistanceAttackPrefab;

    [Header("States")]
    public float sightRange, attackRange,DistanceAttackRange;
    public bool playerInSightRange, playerInAttackRange , playerInDistanceAttackRange;
    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    private void Start()
    {
        player = GameObject.Find("PlayerComponents").transform;
    }
    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInDistanceAttackRange = Physics.CheckSphere(transform.position, DistanceAttackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) ShortDistanceAttackPlayer();
         if (!playerInAttackRange && !playerInSightRange && playerInDistanceAttackRange) LongDistanceAttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 0f, whatIsGround)) walkPointSet = true;
    }

    public void ChasePlayer()
    {
        enemyStats.RangeEnemy = false;
        agent.SetDestination(player.position);
    }

    private void ShortDistanceAttackPlayer()
    {
        agent.SetDestination(transform.position);
        enemyStats.Attack();
    }
    private void LongDistanceAttackPlayer()
    {
        enemyStats.RangeEnemy = true;
        enemyStats.Attack();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
         Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, DistanceAttackRange);
    }
}