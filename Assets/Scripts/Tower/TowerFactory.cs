using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TowerFactory : MonoBehaviour
{
    public Dictionary<Tower.TYPE, GameObject> Towers;

    public GameObject Create(Tower.TYPE type)
    {
        GameObject tower = null;
        Towers.TryGetValue(type, out tower);
        return tower;
    }
}