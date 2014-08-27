using UnityEngine;
using System.Collections;

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

    void Start()
    {
        _lives = 1000;
    }

    void Update()
    {

    }

    void OnGUI()
    {

    }
}