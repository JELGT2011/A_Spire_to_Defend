using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerManager : MonoBehaviour
{
    //
    // Properties
    //

    public GameObject TowerBasic;

    public GameObject TowerType01;

    public GameObject TowerType02;

    public List<GameObject> Towers { get; set; }

    //
    // Methods
    //

    void Start()
    {
        Towers = new List<GameObject>();
    }

    void Update()
    {

    }

    public void CreateTower(Tower.TYPE type, Vector2 Coordinates)
    {
        GameObject temp;
        if (type == Tower.TYPE.basic)
        {
            temp = Instantiate(TowerBasic, new Vector3(Coordinates.x, 0f, Coordinates.y), Quaternion.identity) as GameObject;
            Towers.Add(temp);
        }
    }

    public void DestroyTower(Vector2 Coordinates)
    {
        foreach (GameObject tower in Towers)
        {
            if ((tower.transform.position.x == Coordinates.x) && (tower.transform.position.z == Coordinates.y))
            {
                Destroy(tower);
                return;
            }
        }
    }
}