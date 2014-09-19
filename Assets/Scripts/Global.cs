using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour
{
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

    void Start()
    {
        Towers = new Stack<GameObject>();
    }

    void Update()
    {

    }

    void OnGUI()
    {

    }

    public void CreateTower(GameObject tower, Vector2 coordinates)
    {
        GameObject created = (Instantiate(tower, new Vector3(coordinates.x, 0f, coordinates.y), Quaternion.identity) as GameObject);
        Towers.Push(tower);
    }
}