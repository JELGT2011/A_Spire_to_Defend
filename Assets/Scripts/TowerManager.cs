using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerManager : MonoBehaviour
{
    public GameObject TowerBasic;

    public GameObject TowerType01;

    public GameObject TowerType02;

    protected List<GameObject> _towers;
    public List<GameObject> Towers
    {
        get { return _towers; }
        set { _towers = value; }
    }

    void Start()
    {
        _towers = new List<GameObject>();
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

    public void DestroyTower(GameObject tower)
    {
        foreach (GameObject Tower in _towers)
        {
            if (Tower.Equals(tower))
            {
                _towers.Remove(Tower);
                Destroy(Tower);
                return;
            }
        }
    }
}