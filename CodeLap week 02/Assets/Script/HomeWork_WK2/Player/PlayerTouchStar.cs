using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchStar : MonoBehaviour
{   
    //set playerNumber
    public int playerNumber;
    
    //set scoreManager
    public ScoreManager scoreManager;
    
    //set starSpawner
    public StarSpawner starSpawner;
    
    //set system manager to check gameEnd
    public SystemManager systemManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            Destroy(other.gameObject); //destroy star
            scoreManager.playerScore[playerNumber - 1].score += other.GetComponent<StarScore>().score; //add score
            starSpawner.starSpawn(); //spawn new star
            
            systemManager.gameEnd(); //check if gameEnd
        }
    }
}
