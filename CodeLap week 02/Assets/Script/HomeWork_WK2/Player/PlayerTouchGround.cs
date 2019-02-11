using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchGround : MonoBehaviour
{
    //set variable to store player Number
    public int playerNumber;
    
    //set classs to refer controller
    public PlayerController playerInfo;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            playerInfo.playerInfo[playerNumber - 1].jumpEnable = true;
        }
    }

    public void OnCollisionStay2D(Collision2D other) //check collisionEnter to enable jump in PlayerController
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            playerInfo.playerInfo[playerNumber - 1].jumpEnable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) //check collisionExit to disable jump in PlayerController
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            playerInfo.playerInfo[playerNumber - 1].jumpEnable = false;
        }
    }
}
