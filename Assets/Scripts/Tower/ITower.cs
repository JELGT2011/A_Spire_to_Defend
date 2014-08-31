using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Interface that all tower scripts in tower prefabs must implement.
/// </summary>
public interface ITower
{
    GameObject ProjectileType { get; set; }

    Tower.TYPE Type { get; set; }

    Tower.BEHAVIOR Behavior { get; set; }

    int Cost { get; set; }

    float Created { get; set; }

    int Damage { get; set; }

    float FireRate { get; set; }

    float LastFired { get; set; }

    float Range { get; set; }

    bool IsAlive { get; set; }

    SphereCollider RangeCollider { get; set; }

    List<GameObject> Targets { get; set; }

    GameObject PriorityTarget { get; set; }
}