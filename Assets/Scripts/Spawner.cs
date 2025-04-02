using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;

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
            Enemy newEnemy = Instantiate(_enemyPrefab, GetRandomSpawnPoint());
            newEnemy.SetDirection(GetRandomDirection());

            yield return _time;
        }        
    }

    private Transform GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    private Vector3 GetRandomDirection()
    {
        Vector2 randomCirclePoint = Random.insideUnitCircle.normalized;

        return new Vector3(randomCirclePoint.x, 0f, randomCirclePoint.y);
    }
}
