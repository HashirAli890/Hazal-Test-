using UnityEngine;

public class ChaseState :  MonoBehaviour,IEnemyState
{
    [SerializeField]
    private EnemyController enemy;

    public ChaseState(EnemyController enemy) => this.enemy = enemy;

    public void Enter() { enemy.SetDestinationToPlayer(); }

    public void Tick()
    {
        if (!enemy.IsPlayerVisible())
        {
            enemy.SetState(new PatrolState(enemy));
            return;
        }

        if (enemy.IsInAttackRange())
        {
            enemy.SetState(new AttackState(enemy));
        }
        else
        {
            enemy.SetDestinationToPlayer();
        }
    }

    public void Exit() {}
}
