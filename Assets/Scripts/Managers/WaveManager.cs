using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WaveData[] waves;
    [SerializeField] private ObjectPool enemyPool;

    private int currentWave;

    public void StartWaves() => StartCoroutine(RunWaves());

    private IEnumerator RunWaves()
    {
        while (currentWave < waves.Length)
        {
            var wave = waves[currentWave];

            for (int i = 0; i < wave.enemyCount; i++)
            {
                var enemy = enemyPool.Get();
                enemy.transform.position = wave.spawnPoints[Random.Range(0, wave.spawnPoints.Length)].position;
                // reset enemy state here

                yield return new WaitForSeconds(wave.spawnInterval);
            }

            currentWave++;
        }
    }
}
