using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    //set button to start
    public KeyCode[] pressToStart;
    
    //set inGameElement to Load
    public GameObject[] Level;
    public GameObject inGameSystem;
    public GameObject inGameUI;
    
    //set MenuElement to disable
    public GameObject startMenuUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startGame();
    }

    //set function for startGame
    public void startGame()
    {
        if (Input.GetKeyDown(pressToStart[0]) && !Input.GetKeyDown(pressToStart[1]))
        {
            //enable inGameElement
            Level[0].SetActive(true);
            inGameSystem.SetActive(true);
            inGameUI.SetActive(true);
            
            //disable MenuElement
            startMenuUI.SetActive(false);
            gameObject.SetActive(false);
        }
        
        if (Input.GetKeyDown(pressToStart[1]) && !Input.GetKeyDown(pressToStart[0]))
        {
            //enable inGameElement
            Level[1].SetActive(true);
            inGameSystem.SetActive(true);
            inGameUI.SetActive(true);
            
            //disable MenuElement
            startMenuUI.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
