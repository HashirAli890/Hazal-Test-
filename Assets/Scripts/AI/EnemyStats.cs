using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "AI/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    [Header("Base Stats")]
    public float maxHealth = 100f;
    public float moveSpeed = 3.5f;
    public float detectionRange = 10f;
    public float attackRange = 1.5f;
    public float attackDamage = 10f;
    public float attackCooldown = 1.5f;

    [Header("View")]
    public float viewAngle = 120f; // used for FOV detection
    public float viewDistance = 15f;

    [Header("Death")]
    public float despawnDelay = 2f;
}
