using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using RAIN.Entities.Aspects;
using RAIN.Core;
using RAIN.Perception.Sensors;

/// <summary>
/// Interface that all tower scripts in tower prefabs must implement.
/// </summary>
public interface ITower
{
    GameObject ProjectileType { get; set; }

    int Cost { get; set; }

    float Created { get; set; }

    ProjectileManager ProjectileManager { get; set; }

    Tower.TYPE Type { get; set; }

    Tower.BEHAVIOR Behavior { get; set; }

    int Damage { get; set; }

    float Range { get; set; }

    float FireRate { get; set; }

    IList<RAINAspect> Targets { get; set; }

    SphereCollider RangeCollider { get; set; }

    float LastFired { get; set; }

    bool IsAlive { get; set; }

    GameObject PriorityTarget { get; set; }

    Transform FiringMount { get; set; }

    AIRig AIRig { get; set; }

    VisualSensor VisualSensor { get; set; }
}