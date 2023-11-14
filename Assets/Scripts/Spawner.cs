using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeToLive = 10f;

    private List<SpawnPoint> _spawnPoints = new();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            SpawnPoint spawnPoint = child.GetComponent<SpawnPoint>();

            if (spawnPoint != null)
            {
                _spawnPoints.Add(spawnPoint);
            }
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(2f);

        while (gameObject.activeInHierarchy)
        {
            yield return waitForSeconds;

            SpawnPoint newSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

            Transform pointTransform = newSpawnPoint.transform;

            EnemyMover newEnemy = Instantiate(newSpawnPoint.EnemyPrefab, pointTransform.position,
                pointTransform.rotation);
            
            newEnemy.SetTarget(newSpawnPoint.Target);
            
            Destroy(newEnemy.gameObject, _timeToLive);
        }
    }
}
