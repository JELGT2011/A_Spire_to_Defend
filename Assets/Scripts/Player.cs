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
	private GridPoint lastClickedGridPoint;

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

       	//Debug.LogWarning("spawner still needs full implementation");
        //Debug.LogWarning("add error checking for towers blocking all paths");
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

				GridPoint maybeClicked = LastClickedObject.GetComponent<GridPoint>();

				if(maybeClicked!=null && maybeClicked.CanBuild()){
					if(lastClickedGridPoint!=null){
						lastClickedGridPoint.Deselect();
					}

					lastClickedGridPoint = maybeClicked;	

					lastClickedGridPoint.Select();
				}
                
            }
        }

        if ((Input.GetKeyDown(KeyCode.Alpha0)) && (LastClickedObject != null))
        {
			if(lastClickedGridPoint.CanBuild()){
				lastClickedGridPoint.CreateTower(Global.CreateTower(TowerTypes[0], lastClickedGridPoint.transform.position+Vector3.up));
			}
			else if(lastClickedGridPoint.HasTower()){
				lastClickedGridPoint.DestroyTower();
			}
        }

        if ((Input.GetKeyDown(KeyCode.Alpha1)) && (LastClickedObject != null))
        {
            if(lastClickedGridPoint.CanBuild()){

				lastClickedGridPoint.CreateTower(Global.CreateTower(TowerTypes[1], lastClickedGridPoint.transform.position+Vector3.up));
			}
			else if(lastClickedGridPoint.HasTower()){
				lastClickedGridPoint.DestroyTower();
			}
        }

        if ((Input.GetKeyDown(KeyCode.Alpha2)) && (LastClickedObject != null))
        {
			if(lastClickedGridPoint.CanBuild()){
				lastClickedGridPoint.CreateTower(Global.CreateTower(TowerTypes[2], lastClickedGridPoint.transform.position+Vector3.up));
			}
			else if(lastClickedGridPoint.HasTower()){
				lastClickedGridPoint.DestroyTower();
			}
        }

        if ((Input.GetKeyDown(KeyCode.Alpha3)) && (LastClickedObject != null))
        {
			if(lastClickedGridPoint.CanBuild()){
				
				lastClickedGridPoint.CreateTower(Global.CreateTower(TowerTypes[3], lastClickedGridPoint.transform.position+Vector3.up));
				
			}
			else if(lastClickedGridPoint.HasTower()){
				lastClickedGridPoint.DestroyTower();
			}
        }
    }

    void OnGUI()
    {

    }
}
