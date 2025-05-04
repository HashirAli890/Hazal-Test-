using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public NavMeshAgent agent;

    [Header("Combat Settings")]
    public float attackRange = 2f;
    public float attackRate = 1f;

    [Header("Patrol")]
    public Transform[] Waypoints;

    private int currentWaypointIndex;

    public float AttackRate => attackRate;

    [SerializeField] private EnemyStats stats;

    private float currentHealth;
    private void Start()
    {
        if(stats)
        currentHealth = stats.maxHealth;
          
        SetState(new PatrolState(this));
    }

    private void Update()
    {
        currentState?.Tick();
    }

    public void SetDestinationToPlayer()
    {
        if (player != null)
            agent.SetDestination(player.position);
    }

    public void StopMoving()
    {
        agent.ResetPath();
    }

    public bool IsInAttackRange()
    {
        if (player == null) return false;
        return Vector3.Distance(transform.position, player.position) <= attackRange;
    }

    public bool IsPlayerVisible()
    {
        
        return Vector3.Distance(transform.position, player.position) < 10f;
    }

    public bool ReachedDestination()
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }

    public void SetDestinationToWaypoint(int index)
    {
        if (Waypoints.Length > 0)
            agent.SetDestination(Waypoints[index].position);
    }

    public void AttackPlayer()
    {
        if (player.TryGetComponent<IDamageable>(out var target))
        {
            target.TakeDamage(10f); 
        }
    }

    private IEnemyState currentState;
    public void SetState(IEnemyState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}