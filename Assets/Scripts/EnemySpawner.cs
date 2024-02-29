using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    private float _timeUntilSpawn;
    private bool _hasSpawned = false;

    void Awake()
    {
        SetTimeUntilSpawn();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (!_hasSpawned)
        {
            _timeUntilSpawn -= Time.deltaTime;

            if (_timeUntilSpawn <= 0)
            {
                Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

                // Notify GameManager that an enemy is spawned
                gameManager.UpdateEnemyCount();

                _hasSpawned = true;
            }
        }
    }

    private void SetTimeUntilSpawn()
    {
        if (!_hasSpawned)
        {
            _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
        }
    }
}