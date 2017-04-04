using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour {

    public static gamemanager instance = null;

    [SerializeField]    private GameObject mainMenu;
    [SerializeField]    Camera mainCam;
    [SerializeField]    Camera resetCam;
   

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;
    
    public Text scoreText;
    public int score = 0;
  

    public bool PlayerActive
    {
        get { return playerActive; }
    }

    public bool GameOver
    {
        get { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted; }
    }



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Assert.IsNotNull(mainMenu);

        
        }

    // Use this for initialization
    void Start () {
        scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerCollided()
    {
        gameOver = true;
    }

    

    public void PlayerStartedGame()
    {
        playerActive = true;
    }

    public void EnterGame()
    {
        mainMenu.SetActive(false);
        gameStarted = true;
    }

    public int AddPoint()
    {
        score++;
        scoreText.text = "Score: " + score;
        return score;
    }

    public void RestartScreen()
    {
        if (instance.gameOver == true)
        {
            mainCam.enabled = false;
            resetCam.enabled = true;
        }
    }
}
