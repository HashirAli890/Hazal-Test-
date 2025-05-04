using UnityEngine;

[CreateAssetMenu(menuName = "FPS/Wave Data")]
public class WaveData : ScriptableObject
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public float spawnInterval;
    public Transform[] spawnPoints;
}
