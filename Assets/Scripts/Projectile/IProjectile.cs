using UnityEngine;
using System.Collections;

/// <summary>
/// Interface that all projectile scripts in projectile prefabs must implement.
/// </summary>
public interface IProjectile
{
    Projectile.TYPE Type { get; set; }

    int Damage { get; set; }

    bool IsAlive { get; set; }

    float Speed { get; set; }

    GameObject Target { get; set; }
}