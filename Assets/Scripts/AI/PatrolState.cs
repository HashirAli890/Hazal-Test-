
using UnityEngine;

public class PatrolState :  MonoBehaviour,IEnemyState
{
    [SerializeField]
    private  EnemyController enemy;
    private int waypointIndex;

    public PatrolState(EnemyController enemy) => this.enemy = enemy;

    public void Enter() { enemy.SetDestinationToWaypoint(waypointIndex); }

    public void Tick()
    {
        if (enemy.IsPlayerVisible())
        {
            enemy.SetState(new ChaseState(enemy));
            return;
        }

        if (enemy.ReachedDestination())
        {
            waypointIndex = (waypointIndex + 1) % enemy.Waypoints.Length;
            enemy.SetDestinationToWaypoint(waypointIndex);
        }
    }

    public void Exit() {}
}
