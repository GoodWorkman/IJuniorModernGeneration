using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
   [SerializeField] private float _speed = 3f;
   
   [SerializeField] private PathGroup _pathGroup;

   private List<Transform> _waypoints;

   private int _currentPoint = 0;

   private float _minDistanceValue = 0.001f;

   private void Start()
   {
      if (_pathGroup != null)
      {
         _waypoints = new List<Transform>(_pathGroup.Waypoints);
      }

      StartCoroutine(Move());
   }

   private IEnumerator Move()
   {
      while (gameObject.activeInHierarchy)
      {
         Transform target = _waypoints[_currentPoint];
         
         transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

         if (Vector3.Distance(transform.position, target.position) < _minDistanceValue)
         {
            _currentPoint++;

            if (_currentPoint >= _waypoints.Count)
            {
               _currentPoint = 0;
            }
         }

         yield return null;
      }
   }
   
   
   
   
   
   
   
   
}
