using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemController : MonoBehaviour
{
    //set endGameButton
    public endGameButton endGameButton;
    
    //set state of pauseGame
    public bool pauseGame;
    public bool endGame;
    
    //set systemManager for pause
    public SystemManager systemManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //to initialize start
        pauseGame = false;
        endGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        //set to press pause
        if (Input.GetKeyDown(endGameButton.pause))
        {
            if (pauseGame == false)
            {
                pauseGameEnter();
            }
            else
            {
                pauseGameExit();
            }
        }

        //set what happen in pauseGame
        if (pauseGame == true)
        {
            pauseGameOption();
        }
        
        //set what happen in endgame
        if (endGame == true)
        {
            endOption();
        }
    }

    //how to pause
    public void pauseGameEnter()
    {
        //this work only when endGame is not present
        if (endGame == false)
        {
            //set game state to pause
            pauseGame = true;
            //stop time
            Time.timeScale = 0.0f;
            //toggle pausePanel
            systemManager.pauseGame();
        }
    }
    
    //how pause option works
    public void pauseGameOption()
    {
        //press restart to restart
        if (Input.GetKeyDown(endGameButton.restart))
        {
            print("restart");
            SceneManager.LoadScene("HomeWork_WK2"); //restart scene
            Time.timeScale = 1.0f; //make time move on
            endGame = false; // get out of endGameState
        }
        
        //press qiuit to quit
        if (Input.GetKeyDown(endGameButton.quit))
        {
            print("quit");
            Application.Quit(); // closeGame
        }
    }
    
    //how to unpause
    public void pauseGameExit()
    {
        //this work only when endGame is not present
        if (endGame == false)
        {
            //set game state to pause
            pauseGame = false;
            //resume time
            Time.timeScale = 1.0f;
            //toggle pause game panel
            systemManager.pauseGame();
        }
    }
    
    //entering endGame
    public void endGameEnter()
    {
        //set endgameState
        endGame = true;
        
        //stop game
        Time.timeScale = 0.0f;
    }
    
    //how end work
    public void endOption()
    {
        //press restart to restart
        if (Input.GetKeyDown(endGameButton.restart))
        {
            print("restart");
            SceneManager.LoadScene("HomeWork_WK2"); //restart scene
            Time.timeScale = 1.0f; //make time move on
            endGame = false; // get out of endGameState
        }
        
        //press qiuit to quit
        if (Input.GetKeyDown(endGameButton.quit))
        {
            print("quit");
            Application.Quit(); // closeGame
        }
    }
}

[System.Serializable]
//set up player class to assign button
public class endGameButton
{
    public KeyCode pause;
    public KeyCode restart;
    public KeyCode quit;
}

