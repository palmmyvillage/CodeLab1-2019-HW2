using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //initiate the class
    public Player_Score[] playerScore;

}

[System.Serializable]
//set up score for each player
public class Player_Score
{
    public string name;
    public int score;
}