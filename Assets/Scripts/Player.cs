using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string name;
    public int score;

    // Constructor
    public Player(string playerName, int playerScore)
    {
        name = playerName;
        score = playerScore;
    }
}
