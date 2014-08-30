using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int Gold;

    public int PlayerNumber;

    public TowerManager TowerManager;

    protected Ray Ray { get; protected set; }

    public Vector2 LastClickedCoordinates { get; protected set; }
    
    public GameObject LastObjectClicked { get; protected set; }

    public RaycastHit RaycastHit;

    void Start()
    {
        TowerManager = GetComponent<TowerManager>();
        LastClickedCoordinates = new Vector2(0f, 0f);

        Debug.LogWarning("spawner still needs full implementation");
        Debug.LogWarning("incorporate RAIN pathfinding");
        Debug.LogWarning("set more public variables for easier testing (for enemies)");
    }

    void Update()
    {
        // Determines what the player clicked on
        if (Input.GetMouseButtonDown(0))
        {
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Ray, out RaycastHit))
            {
                LastObjectClicked = RaycastHit.transform.collider.gameObject;

                if (LastObjectClicked.tag == "Build Area")
                {
                    LastClickedCoordinates = new Vector2((float) Mathf.RoundToInt(RaycastHit.point.x), (float)Mathf.RoundToInt(RaycastHit.point.z));
                }
                else if (LastObjectClicked.tag == "Tower")
                {

                }
                else if (LastObjectClicked.tag == "Enemy")
                {

                }
                else
                {

                }
            }
        }

        if ((Input.GetKeyDown(KeyCode.Alpha0)) && (LastObjectClicked != null))
        {
            if (LastObjectClicked.tag == "Build Area")
            {

            }
            else if (LastObjectClicked.tag == "Tower")
            {

            }
            else if (LastObjectClicked.tag == "Enemy")
            {

            }
        }

        if ((Input.GetKeyDown(KeyCode.Alpha1)) && (LastObjectClicked != null))
        {
            if (LastObjectClicked.tag == "Build Area")
            {
                TowerManager.CreateTower(Tower.TYPE.basic, LastClickedCoordinates);
            }
            else if (LastObjectClicked.tag == "Tower")
            {
                TowerManager.DestroyTower(LastObjectClicked.transform.root.gameObject);
            }
            else if (LastObjectClicked.tag == "Enemy")
            {

            }
        }

        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (LastObjectClicked != null))
        {
            if (LastObjectClicked.tag == "Build Area")
            {

            }
            else if (LastObjectClicked.tag == "Tower")
            {

            }
            else if (LastObjectClicked.tag == "Enemy")
            {

            }
        }

        if ((Input.GetKeyDown(KeyCode.Alpha3)) && (LastObjectClicked != null))
        {
            if (LastObjectClicked.tag == "Build Area")
            {

            }
            else if (LastObjectClicked.tag == "Tower")
            {

            }
            else if (LastObjectClicked.tag == "Enemy")
            {

            }
        }
    }

    void OnGUI()
    {

    }
}
