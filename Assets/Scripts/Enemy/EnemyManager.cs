using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



public class EnemyManager : MonoBehaviour
{
    public GameObject[] EnemyTypes;

    public List<GameObject> Enemies;

    public Player[] Players;

    public Stack<Pair<Tower, Player>> LastAdded;

    public NavMeshAgent NavMeshAgent { get; set; }

    void Start()
    {
        Enemies = new List<GameObject>();
        NavMeshAgent = GetComponentInChildren<NavMeshAgent>();
        LastAdded = new Stack<Pair<Tower, Player>>();

    }

    void Update()
    {
        if (!NavMeshAgent.hasPath)
        {
            Pair<Tower, Player> lastAdded = LastAdded.Pop();

            // refund the cost of the tower
            lastAdded.Item2.Gold += lastAdded.Item1.Cost;

            // destroy blocking tower
            lastAdded.Item2.TowerManager.DestroyTower(lastAdded.Item1.gameObject);

            Debug.LogWarning("create error message to player that tower blocks path");
        }
    }
}
