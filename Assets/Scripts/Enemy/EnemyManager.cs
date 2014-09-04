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

    public Transform SpawnPlatform { get; set; }

    void Start()
    {
        Enemies = new List<GameObject>();
        NavMeshAgent = GetComponentInChildren<NavMeshAgent>();
        Global = GameObject.FindGameObjectWithTag("Global").GetComponentInChildren<Global>();

        SpawnPlatform = transform.Find("Spawn Platform");

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
                CreateEnemy(EnemyTypes[0]);
                LastSpawned = 0;
            }
            else
            {
                LastSpawned += Time.deltaTime;
            }
        }

        if (!NavMeshAgent.hasPath)
        {
            GameObject removed = Global.Towers.Pop();
            Global.Gold += (removed.GetComponentInChildren(typeof(ITower)) as ITower).Cost;

            Debug.LogWarning("create error message to player that tower blocks path");
        }
    }

    public void CreateEnemy(GameObject enemy)
    {
        // find and navigate to target
        GameObject _enemy = Instantiate(enemy, SpawnPlatform.position, Quaternion.identity) as GameObject;
        (_enemy.GetComponentInChildren(typeof(IEnemy)) as IEnemy).Target = GameObject.Find("Finish").GetComponent<Transform>().position;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 20, Screen.height - 20, 20, 20), "Spawn"))
        {
            Spawn = !Spawn;
        }
    }
}
