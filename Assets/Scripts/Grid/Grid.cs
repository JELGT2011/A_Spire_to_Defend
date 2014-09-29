using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public static Grid Instance;//Singletons forever

	public Vector2 minCorner = new Vector2(0,5);
	public Vector2 mapSize = new Vector2(10,5);
	private GridPoint[,] map;

	private const string GRIDPOINT_TAG = "GridPoint";

	void Awake(){
		//Get dem GridPoints
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (GRIDPOINT_TAG);

		map = new GridPoint[(int)mapSize.x, (int)mapSize.y];

		foreach (GameObject g in gameObjects) {
			GridPoint gridPoint = g.GetComponent<GridPoint>();

			if(gridPoint!=null){
				map[(int)(g.transform.position.x-minCorner.x),(int)(g.transform.position.z-minCorner.y)] = gridPoint;
			}
		}

		if (Instance == null) {
			Instance =this;	
		}
	}

	public GridPoint GetGridPoint(GridPoint point){
		return GetGridPoint (point.transform.position.x, point.transform.position.z);
	}

	public GridPoint GetGridPoint(float x, float z){
		return GetGridPoint ((int)x, (int)z);
	}

	public GridPoint GetGridPoint(int x, int z){

		x -= (int)minCorner.x;
		z-= (int) minCorner.y;

		GridPoint toReturn = null;
		if(x>=0 && z>=0 && x<mapSize.x && z<mapSize.y){
			return map[x,z];
		}

		return toReturn;
	}
}
