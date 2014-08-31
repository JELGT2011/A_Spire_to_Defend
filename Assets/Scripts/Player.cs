using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public int _gold;
    public int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    public GameObject[] TowerTypes;

    public int PlayerNumber { get; protected set; }

    public TowerManager TowerManager { get; set; }

    public Vector2 LastClickedCoordinates { get; protected set; }

    public Ray Ray { get; protected set; }

    public GameObject LastClickedObject { get; protected set; }

    public RaycastHit _raycastHit;
    public RaycastHit RaycastHit
    {
        get { return _raycastHit; }
        protected set { _raycastHit = value; }
    }

    void Start()
    {
        TowerManager = ScriptableObject.CreateInstance<TowerManager>();

        Debug.Log("");

        List<GameObject> towerList = new List<GameObject>();
        towerList.Add(TowerTypes[0]);

        TowerManager.Init(towerList);
        LastClickedCoordinates = new Vector2(0f, 0f);

        Debug.LogWarning("spawner still needs full implementation");
    }

    void Update()
    {
        // Determines what the player clicked on
        if (Input.GetMouseButtonDown(0))
        {
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Ray, out _raycastHit))
            {
                LastClickedObject = _raycastHit.transform.collider.gameObject;

                if (LastClickedObject.tag == "Build Area")
                {
                    LastClickedCoordinates = new Vector2((float) Mathf.RoundToInt(_raycastHit.point.x), (float)Mathf.RoundToInt(_raycastHit.point.z));
                }
                else if (LastClickedObject.tag == "Tower")
                {

                }
                else if (LastClickedObject.tag == "Enemy")
                {

                }
                else
                {

                }
            }
        }

        if ((Input.GetKeyDown(KeyCode.Alpha0)) && (LastClickedObject != null))
        {
            if (LastClickedObject.tag == "Build Area")
            {

            }
            else if (LastClickedObject.tag == "Tower")
            {

            }
            else if (LastClickedObject.tag == "Enemy")
            {

            }
        }

        if ((Input.GetKeyDown(KeyCode.Alpha1)) && (LastClickedObject != null))
        {
            if (LastClickedObject.tag == "Build Area")
            {
                TowerManager.CreateTower(Tower.TYPE.basic, LastClickedCoordinates);
            }
            else if (LastClickedObject.tag == "Tower")
            {
                TowerManager.DestroyTower(LastClickedObject.transform.root.gameObject);
            }
            else if (LastClickedObject.tag == "Enemy")
            {

            }
        }

        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (LastClickedObject != null))
        {
            if (LastClickedObject.tag == "Build Area")
            {

            }
            else if (LastClickedObject.tag == "Tower")
            {

            }
            else if (LastClickedObject.tag == "Enemy")
            {

            }
        }

        if ((Input.GetKeyDown(KeyCode.Alpha3)) && (LastClickedObject != null))
        {
            if (LastClickedObject.tag == "Build Area")
            {

            }
            else if (LastClickedObject.tag == "Tower")
            {

            }
            else if (LastClickedObject.tag == "Enemy")
            {

            }
        }
    }

    void OnGUI()
    {

    }
}
