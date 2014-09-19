using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Factory : ScriptableObject
{
    public static Dictionary<Enemy.TYPE, GameObject> Enemies { get; set; }

    public static Dictionary<Tower.TYPE, GameObject> Towers { get; set; }

    public static Dictionary<Projectile.TYPE, GameObject> Projectiles { get; set; }

    public static GameObject CreateEnemy(Enemy.TYPE type)
    {
        GameObject enemy = Enemies[type];
        return enemy;
    }

    public static GameObject CreateTower(Tower.TYPE type)
    {
        GameObject tower = Towers[type];
        return tower;
    }

    public static GameObject CreateProjectile(Projectile.TYPE type)
    {
        GameObject projectile = Projectiles[type];
        return projectile;
    }
}