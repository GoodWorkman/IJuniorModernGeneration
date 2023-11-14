using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGroup : MonoBehaviour
{
    private readonly List<Transform> _waypoints = new();

    public IReadOnlyList<Transform> Waypoints => _waypoints;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            _waypoints.Add(child);
        }
    }
}
