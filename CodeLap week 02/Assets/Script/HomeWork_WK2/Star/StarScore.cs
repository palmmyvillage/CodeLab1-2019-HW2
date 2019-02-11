using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScore : MonoBehaviour
{
    //set object Variable to store starManager ingfo
    public GameObject starManager;
    
    //set number to indicate color of star
    public int starColor;
    
    //set int score refer from starManager
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        starManager = GameObject.Find("StarManager");
        score = starManager.GetComponent<StarManager>().starsInfo[starColor - 1].score;
    }
}
