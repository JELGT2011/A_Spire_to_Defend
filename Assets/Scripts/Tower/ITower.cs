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

    int Damage { get; set; }

    float FireRate { get; set; }

    float LastFired { get; set; }

    float Range { get; set; }

    bool IsAlive { get; set; }

    RAIN.Core.AIRig AIRig { get; set; }

    IList<RAIN.Entities.Aspects.RAINAspect> Targets { get; set; }

    GameObject PriorityTarget { get; set; }

    RAIN.Perception.Sensors.VisualSensor VisualSensor { get; set; }
}