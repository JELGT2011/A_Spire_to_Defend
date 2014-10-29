using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour
{	public static Global Instance; //Singleton

    public static int MAX_PLAYERS = 4;
    public static int NUM_PLAYERS = 0;

	[SerializeField]
	private int lives = 20;
	[SerializeField]
	private int resources = 200;

    public List<GameObject> Towers { get; set; }

	private List<Enemy> Enemies;

	private const string RESOURCES_TEXT = "Resources: ";
	private const string LIFE_TEXT = "";

	public GUIText lifeText, resourcesText;

	private EnemySpawner[] enemySpanwers;

	private const string LEVEL_SELECT = "Levels";

	public AudioClip onTowerSpawn;

	private GUIRunner guiRunner;

    void Start()
    {
        Towers = new List<GameObject>();
		Enemies = new List<Enemy> ();

		if (Instance == null) {
			Instance = this;		
		}

//		resourcesText.text = RESOURCES_TEXT + "" + resources;
//		lifeText.text = LIFE_TEXT + "" + lives;

		enemySpanwers = GameObject.FindObjectsOfType<EnemySpawner> ();

		guiRunner = gameObject.GetComponent<GUIRunner>();
		guiRunner.Setup(lives, resources);
    }

    public Tower CreateTower(GameObject tower, Vector3 coordinates){
		GameObject created = (Instantiate(tower) as GameObject);
		created.transform.position = coordinates;
		Towers.Add(created);
		Tower t = created.GetComponent<Tower> ();
		
		AlterResources(-1*t.GetCost ());

		//TODO; Make a sound
		if (onTowerSpawn != null) {
			AudioSource.PlayClipAtPoint(onTowerSpawn,transform.position);
		}

		return t;
    }

	public bool CanBuild(Tower tower){
		return resources >= tower.GetCost ();
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

	public void AlterResources(int resourceGain){
		resources += resourceGain;

		if (resources < 0) {
			resources = 0;		
		}

//		resourcesText.text = RESOURCES_TEXT + "" + resources;
		guiRunner.SetResourceDisplay(resources);
	}

	public void AlterLives(int lifeDamage){
		lives -= lifeDamage;

		if (lives <= 0) {
			//TODO; something smarter here. For now reload
			Application.LoadLevel(Application.loadedLevelName);
		}

//		lifeText.text = LIFE_TEXT + "" + lives;
		guiRunner.SetHealthDisplay(lives);
	}

	public void SetUpTowerInfo(TowerInfo[] towerInfos){
		float start = 0.15f;
		float diff = 0.2f;

		for(int i = 0; i<towerInfos.Length; i++){
			GameObject tower = GameObject.Instantiate(towerInfos[i].gameObject) as GameObject;

			tower.transform.position = new Vector3(start+diff*i,0.05f, 20f);

			tower.GetComponent<TowerInfo>().SetNumber(i+1);
		}

	}

	//See if we won
	void Update(){
		bool allDone = true;

		foreach (EnemySpawner e in enemySpanwers) {
			if(!e.IsDone()){
				allDone=false;
			}
		}

		if(allDone && Enemies.Count==0){
			//We're done! 

			//TODO; Something Better
			Application.LoadLevel(LEVEL_SELECT);
		}
	}



}