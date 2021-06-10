using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfig[] _waveConfigs;

    int _startingWave = 0;

    void Start()
    {
        var currentWave = _waveConfigs[_startingWave];

        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
    {
        var waypoints = currentWave.GetWaypoints().ToArray();

        for (int i = 0; i < currentWave.NumberOfNames; i++)
        {
            var enemy = Instantiate(currentWave.EnemyPrefab, waypoints[0].position, Quaternion.identity);
            var pathing = enemy.GetComponent<EnemyPathing>();

            pathing.WaveConfig = currentWave;

            yield return new WaitForSeconds(currentWave.TimeBetweenSpawns);
        }
    }
}