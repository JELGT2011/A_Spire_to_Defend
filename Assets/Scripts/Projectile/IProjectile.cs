using UnityEngine;
using System.Collections;

/// <summary>
/// Interface that all projectile scripts in projectile prefabs must implement.
/// </summary>
public interface IProjectile
{
    public Projectile.TYPE Type;

    public int Damage;

    public bool IsAlive;

    public float Speed;

    public GameObject Target;
}