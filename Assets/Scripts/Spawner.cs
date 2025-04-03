using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    [SerializeField] private float _delay = 2f;
    [SerializeField] private bool _isActiveSpawn = true;
    private WaitForSecondsRealtime _time;

    private void Start()
    {
        _time = new WaitForSecondsRealtime(_delay);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (_isActiveSpawn)
        {
            GetRandomSpawnPoint().SpawnEnemy();

            yield return _time;
        }        
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }
}
