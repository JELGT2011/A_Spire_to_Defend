using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public GameObject[] TowerTypes;

    public int PlayerNumber { get; protected set; }

    public Vector2 LastClickedCoordinates { get; protected set; }

    public Ray Ray { get; protected set; }

    public GameObject LastClickedObject { get; protected set; }

    public RaycastHit _raycastHit;
    public RaycastHit RaycastHit
    {
        get { return _raycastHit; }
        protected set { _raycastHit = value; }
    }

    public Global Global { get; set; }

    void Start()
    {
        LastClickedCoordinates = new Vector2(0f, 0f);
        Global = GameObject.FindGameObjectWithTag("Global").GetComponentInChildren<Global>();

        Debug.LogWarning("spawner still needs full implementation");
        Debug.LogWarning("add error checking for towers blocking all paths");
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
                Global.CreateTower(TowerTypes[1], LastClickedCoordinates);
            }
            else if (LastClickedObject.tag == "Tower")
            {
                //TowerManager.DestroyTower(LastClickedObject.transform.root.gameObject);
            }
            else if (LastClickedObject.tag == "Enemy")
            {

            }
        }

        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (LastClickedObject != null))
        {
            if (LastClickedObject.tag == "Build Area")
            {
                Global.CreateTower(TowerTypes[2], LastClickedCoordinates);
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
                Global.CreateTower(TowerTypes[3], LastClickedCoordinates);
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
