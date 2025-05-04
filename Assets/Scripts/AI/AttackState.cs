
using UnityEngine;

public class AttackState :  MonoBehaviour,IEnemyState
{
    [SerializeField]
    private  EnemyController enemy;
    private float lastAttackTime;


    public AttackState(EnemyController enemy) => this.enemy = enemy;

    public void Enter() => enemy.StopMoving();

    public void Tick()
    {
        if (!enemy.IsInAttackRange())
        {
            
            enemy.SetState(new ChaseState(enemy));
            return;
        }

        if (Time.time >= lastAttackTime + 1f / enemy.AttackRate)
        {
            enemy.AttackPlayer();
            lastAttackTime = Time.time;
        }
    }

    public void Exit() {}
}
