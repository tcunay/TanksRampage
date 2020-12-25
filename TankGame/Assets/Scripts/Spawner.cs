using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private KillCounter _killCounter;

    [SerializeField] private int _delaySpawn = 30;
    [SerializeField] private int _increaseEnemies = 1;
    [SerializeField] private int _initialQuantityEnemies = 2;

    private Vector3[] _spawnPoints;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    private IEnumerator SpawnEnemies()
    {
        var waitForSeconds = new WaitForSeconds(_delaySpawn);
        int currentQyantity = _initialQuantityEnemies;
        int waveNumber = 1;

        while (true)
        {
            Debug.Log("Wave = " + waveNumber++);
            CreateEnemy(currentQyantity);
            currentQyantity += _increaseEnemies;
            yield return waitForSeconds;
        }
    }
    private void CreateEnemy(int qantityEnemies)
    {
        _spawnPoints = new Vector3[qantityEnemies];

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = SetLocation();
           var enemy = Instantiate(_enemy, _spawnPoints[i], Quaternion.identity);
            enemy.EnemyDied += _killCounter.OnKillsChanged;
        }
    }

    private Vector3 SetLocation()
    {
        return new Vector3(Random.Range(-22f, 22f), 1.1f , Random.Range(3f, 33f));
    }



}

