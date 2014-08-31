using UnityEngine;
using System.Collections;

public class ProjectileManager : ScriptableObject
{
    public int Capacity { get; protected set; }

    public GameObject[] Projectiles { get; set; }

    public GameObject Projectile { get; set; }

    public int Last { get; protected set; }

    public void Init(int capacity, GameObject projectile)
    {
        Capacity = capacity;
        Projectiles = new GameObject[capacity];
        Projectile = projectile;
    }

    public void CreateProjectile(Vector3 position, Quaternion rotation)
    {
        if (Projectiles[Last])
        {
            Destroy(Projectiles[Last]);
        }
        Projectiles[Last] = Instantiate(Projectile, position, rotation) as GameObject;
        Last = (Last + 1) % Capacity;
    }
}