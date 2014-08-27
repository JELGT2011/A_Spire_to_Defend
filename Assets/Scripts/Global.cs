using UnityEngine;
using System.Collections;

public class Global
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
}