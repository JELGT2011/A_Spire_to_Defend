using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] EnemyTypes;

    public List<GameObject> Enemies;

    public float LastSpawned { get; set; }

    public float SpawnFrequency { get; set; }

    public bool Spawn { get; set; }

    public NavMeshAgent NavMeshAgent { get; set; }

    public Global Global { get; set; }

    public int _spawnPoints;
    public int SpawnPoints
    {
        get { return _spawnPoints; }
        set { _spawnPoints = value; }
    }

    public GameObject[] SpawnRigs { get; set; }

    public GameObject[] SpawnPlatforms { get; set; }

    public GameObject[] FinishPoints { get; set; }

    void Start()
    {
        Enemies = new List<GameObject>();
        NavMeshAgent = GetComponentInChildren<NavMeshAgent>();
        Global = GameObject.FindGameObjectWithTag("Global").GetComponentInChildren<Global>();

        for (int i = 0; i < SpawnPoints; i++)
        {
            SpawnRigs[i] = transform.Find("Spawn Rig 0" + i.ToString()).gameObject;
            SpawnPlatforms[i] = SpawnRigs[i].transform.Find("Spawn Platform").gameObject;
            FinishPoints[i] = SpawnRigs[i].transform.Find("Finish").gameObject;
        }

        LastSpawned = 0;
        SpawnFrequency = 1f;
    }

    void Update()
    {

        if (Spawn)
        {
            // begin spawning enemies
            if (LastSpawned >= SpawnFrequency)
            {
                CreateEnemy(0, EnemyTypes[0]);
                LastSpawned = 0;
            }
            else
            {
                LastSpawned += Time.deltaTime;
            }
        }
    }

    public void CreateEnemy(int spawnPoint, GameObject enemy)
    {
        // find and navigate to target
        GameObject newEnemy = Instantiate(enemy, SpawnPlatforms[spawnPoint].transform.position, Quaternion.identity) as GameObject;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 20, Screen.height - 20, 20, 20), "Spawn"))
        {
            Spawn = !Spawn;
        }
    }
}
