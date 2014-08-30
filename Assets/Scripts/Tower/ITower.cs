using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Interface that all tower scripts in tower prefabs must implement.
/// </summary>
public interface ITower
{
    public GameObject ProjectileType;

    public Tower.TYPE Type;

    public Tower.BEHAVIOR Behavior;

    public int Damage;

    public float FireRate;

    public float LastFired;

    public float Range;

    public bool IsAlive;

    public RAIN.Core.AIRig AIRig;

    public IList<RAIN.Entities.Aspects.RAINAspect> Targets;

    public GameObject PriorityTarget;

    public RAIN.Perception.Sensors.VisualSensor VisualSensor;
}