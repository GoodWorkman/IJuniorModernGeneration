using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyPrefab;
    [SerializeField] private Transform _target;

    public EnemyMover EnemyPrefab => _enemyPrefab;
    public Transform Target => _target;
}