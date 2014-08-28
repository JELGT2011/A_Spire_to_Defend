﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Interface that all enemy scripts in enemy prefabs must implement.
/// </summary>
public interface IEnemy
{
    Enemy.TYPE Type { get; set; }

    int MaxHealth { get; set; }

    int CurrentHealth { get; set; }

    float Speed { get; set; }

    bool IsAlive { get; set; }

    bool TargetReached { get; set; }

    NavMeshAgent NavMeshAgent { get; set; }

    float Accuracy { get; set; }

    float Distance { get; set; }

    Vector3 Target { get; set; }
}