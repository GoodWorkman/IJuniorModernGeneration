using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;

    private Transform _target;

    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }
    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (gameObject.activeInHierarchy)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            transform.Translate(direction * (_speed * Time.deltaTime), Space.World);

            if (direction != Vector3.zero)
            {
                transform.forward = direction;
            }
            
            yield return null;
        }
    }
}
