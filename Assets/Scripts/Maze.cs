using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour
{

    protected Player Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
