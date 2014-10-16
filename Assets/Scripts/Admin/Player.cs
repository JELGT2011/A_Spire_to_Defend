using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public GameObject[] TowerTypes;
	private KeyCode[] towerkeys = new KeyCode[]{KeyCode.Alpha1,KeyCode.Alpha2,KeyCode.Alpha3,KeyCode.Alpha4,KeyCode.Alpha5,KeyCode.Alpha6,KeyCode.Alpha7,KeyCode.Alpha8,KeyCode.Alpha9};

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


    void Start()
    {
        LastClickedCoordinates = new Vector2(0f, 0f);

		TowerInfo[] towerInfos = new TowerInfo[TowerTypes.Length];

		for (int i = 0; i<towerInfos.Length; i++) {
			towerInfos[i] = TowerTypes[i].GetComponent<Tower>().myInfo;		
		}

		Global.Instance.SetUpTowerInfo (towerInfos);
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

		//Determine which tower to make
		for(int i = 0; i<TowerTypes.Length; i++){
			if(Input.GetKeyDown(towerkeys[i])){
				Tower t = TowerTypes[i].GetComponent<Tower>();
				if(lastClickedGridPoint.CanBuild() && Global.Instance.CanBuild(t)){
					//TODO; build tower sound
					lastClickedGridPoint.CreateTower(Global.Instance.CreateTower(TowerTypes[i], lastClickedGridPoint.transform.position+Vector3.up));
				}
				else if(lastClickedGridPoint.HasTower()){
					//TODO; make can't make tower sound
					lastClickedGridPoint.DestroyTower();
					lastClickedGridPoint.CreateTower(Global.Instance.CreateTower(TowerTypes[i], lastClickedGridPoint.transform.position+Vector3.up));
				}
				else{
					//TODO; Didn't work sound
				}
			}
		}

    }
}
