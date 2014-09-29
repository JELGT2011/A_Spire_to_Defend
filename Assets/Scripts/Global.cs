using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour
{	public static Global Instance; //Singleton

    public static int MAX_PLAYERS = 4;
    public static int NUM_PLAYERS = 0;

    public enum DIFFICULTY
    {
        noobsauce,
        gamer,
        hell
    }

    public enum GAME 
    {
        mainmenu,
        lobby,
        game,
        paused,
        endgame
    }

    protected int _lives;
    public int Lives
    {
        get { return _lives; }
        set { _lives = value; }
    }

    protected int _gold;
    public int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    public Stack<GameObject> Towers { get; set; }

	public List<Enemy> Enemies;

    void Start()
    {
        Towers = new Stack<GameObject>();
		Enemies = new List<Enemy> ();

		if (Instance == null) {
			Instance = this;		
		}
    }

    void Update()
    {

    }

    void OnGUI()
    {

    }

    public Tower CreateTower(GameObject tower, Vector3 coordinates)
    {
		Debug.Log ("Coordinates: " + coordinates);
		GameObject created = (Instantiate(tower) as GameObject);
		created.transform.position = coordinates;
		Towers.Push(created);

		return created.GetComponent<Tower> ();
    }

	public void AddEnemy(Enemy enemy){
		Enemies.Add (enemy);
	}

	public void RemoveEnemy(Enemy enemy){
		Enemies.Remove (enemy);
	}

	public Enemy GetClosestEnemy(Vector3 pos){
		float distBetween = 1000.0f;
		Enemy enemy = Enemies [0];

		foreach (Enemy e in Enemies) {
			float sqrDist = (e.transform.position-pos).sqrMagnitude;
			if(sqrDist<distBetween){
				distBetween = sqrDist;
				enemy = e;
			}
		}
		return enemy;
	}

	public Enemy GetAnyEnemy(){
		Enemy enemy = null;

		if (Enemies.Count != 0) {
			enemy = Enemies[0];	
		}
		return enemy;
	}

	public Enemy GetFirstInRange(Vector3 pos, float range){
		foreach (Enemy e in Enemies) {
			if ((e.transform.position - pos).magnitude < range) {
				return e;
					
			}
		}
		return null;

	}


}