using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemManager : MonoBehaviour
{
    //set starSpawner and ScoreManager
    public StarSpawner starSpawner;
    public ScoreManager scoreManager;
    public SystemController systemController;
    
    //set pauseGamePanel
    public GameObject pausePanel;
    
    //set gamePanel and text
    public GameObject endPanel;
    public Text winner;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //toggle pause panel
    public void pauseGame()
    {
        pausePanel.SetActive(!pausePanel.activeInHierarchy);
    }
    
    //use this when game ends (all star spawn and collected)
    public void gameEnd()
    {
        if (starSpawner.maxSpawn <= 0)
        {
            StartCoroutine(endGame());
        }
    }

    //set to pause game after the last Star got captured
    IEnumerator endGame()
    {
        yield return 0;
        if (GameObject.FindGameObjectWithTag("Star") == null)
        {
            int P1score = scoreManager.playerScore[0].score;
            int P2score = scoreManager.playerScore[1].score;

            endPanel.SetActive(true);
            if (P1score > P2score)
            {
                endPanel.GetComponent<Image>().color = new Color(0.5f, 0.0f, 0.0f, 0.6f);
                winner.text = "Player1 Win";
                winner.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else if (P1score < P2score)
            {
                endPanel.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.5f, 0.6f);
                winner.text = "Player2 Win";
                winner.color = new Color(0.2f, 0.4f, 1.0f, 1.0f);
            }
            else if (P1score == P2score)
            {
                endPanel.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.6f);
                winner.text = "Draw";
                winner.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            }
            systemController.endGameEnter();
        }
    }
}
