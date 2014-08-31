using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerManager : ScriptableObject
{
    public List<GameObject> TowerTypes;

    public List<GameObject> Towers;

    public void Init(List<GameObject> towerList)
    {
        Towers = new List<GameObject>();
        TowerTypes = towerList;
    }

    public void CreateTower(Tower.TYPE type, Vector2 Coordinates)
    {
        GameObject tower;

        if (type == Tower.TYPE.basic)
        {
            tower = Instantiate(TowerTypes[0], new Vector3(Coordinates.x, 0f, Coordinates.y), Quaternion.identity) as GameObject;
            Towers.Add(tower);
        }
    }

    public void DestroyTower(GameObject tower)
    {
        foreach (GameObject Tower in Towers)
        {
            if (Tower.Equals(tower))
            {
                Towers.Remove(Tower);
                Destroy(Tower);
                return;
            }
        }
    }
}