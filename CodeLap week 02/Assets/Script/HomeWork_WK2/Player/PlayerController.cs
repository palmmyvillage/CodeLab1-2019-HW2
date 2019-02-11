using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //initiate the player class
    public Player_Info[] playerInfo;

    //set variable for storing force to move Player
    public float xSpeedLimit;
    public float forceInput;
    public float jumpInput;
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        //add Gravity
        //use for so that it apply to any number of players
        for (int i = 0; i < playerInfo.Length; i++)
        {
            playerGravity(i);
            playerRotation(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //add Abilities to Run and Jump
        //use for so that it apply to any number of players
        for (int i = 0; i < playerInfo.Length; i++)
        {
            playerRunning(i);
            playerJumping(i);
        }
    }

    //set function to move each player with force
    public void playerRunning(int playerNumber) //set how player run
    {
        // set updated speed
        float xSpeed = playerInfo[playerNumber].rigidBody.velocity.x;
        float ySpeed = playerInfo[playerNumber].rigidBody.velocity.y;

        //force will always add to player
        Vector2 newForce = new Vector2();

        //Horizontal movement
        if (Input.GetKey(playerInfo[playerNumber].Left)) //move left
        {
            newForce.x -= forceInput;
        }

        if (Input.GetKey(playerInfo[playerNumber].Right)) //move right
        {
            newForce.x += forceInput;
        }

        //set limitSpeed to moving Horizontal
        if (xSpeed >= xSpeedLimit)
        {
            playerInfo[playerNumber].rigidBody.velocity = new Vector2(xSpeedLimit, ySpeed);
        }
        else if (xSpeed <= -xSpeedLimit)
        {
            playerInfo[playerNumber].rigidBody.velocity = new Vector2(-xSpeedLimit, ySpeed);
        }

        // add new force to object to move
        playerInfo[playerNumber].rigidBody.AddForce(newForce);
    }

    public void playerGravity(int playerNumber) //set how player affected by gravity
    {
        playerInfo[playerNumber].rigidBody.gravityScale = gravity;
    }

    public void playerJumping(int playerNumber) //set how player Jump
    {
        float xSpeed = playerInfo[playerNumber].rigidBody.velocity.x;
        float ySpeed = playerInfo[playerNumber].rigidBody.velocity.y;
        
        //set bool to use for this one
        bool jumpEnable = playerInfo[playerNumber].jumpEnable;
        KeyCode jumpButton = playerInfo[playerNumber].Up;

        //force will always add to player
        Vector2 newForce = new Vector2();

        //check if jump possible or not
        if (jumpEnable == true)
        {
            if (Input.GetKeyDown(jumpButton)) //jump
            {
                playerInfo[playerNumber].rigidBody.velocity = new Vector2(xSpeed,0);
                StartCoroutine(nullifyFalling(playerNumber));
            }
        }
    }

    public void playerRotation(int playerNumber) // set ability to rotate player
    {
        playerInfo[playerNumber].rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    
    IEnumerator nullifyFalling(int playerNumber) //nullify falling velocity before making A JUMP
    {
        yield return 0;
        //force will always add to player
        Vector2 newForce = new Vector2();
        newForce.y += jumpInput;
        playerInfo[playerNumber].rigidBody.AddForce(newForce);
    }
}

[System.Serializable]
//set up player class to assign button and statistic
public class Player_Info
{
    public string name;
    public Rigidbody2D rigidBody;
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
    public bool jumpEnable;
}
