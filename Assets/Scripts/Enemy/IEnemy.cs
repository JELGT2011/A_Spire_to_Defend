using UnityEngine;
using System.Collections;

/// <summary>
/// Interface that all enemy scripts in enemy prefabs must implement.
/// </summary>
public interface IEnemy
{
    public Enemy.TYPE Type;

    public int MaxHealth;

    public int CurrentHealth;

    public float MaxSpeed;

    public float CurrentSpeed;

    public bool IsAlive;

    public bool TargetReached;

    public NavMeshAgent NavMeshAgent;

    public float Accuracy;

    public float Distance;

    public Vector3 Target;
}