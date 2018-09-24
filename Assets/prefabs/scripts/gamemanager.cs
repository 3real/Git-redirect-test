using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class gamemanager : MonoBehaviour {

    public static gamemanager instance = null;

    [SerializeField]    private GameObject mainMenu;
    [SerializeField]    Camera mainCam;
    [SerializeField]    Camera resetCam;

    [SerializeField]    private AudioClip buttonPressed;
   

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;

    private AudioSource audioSource;
    
    public Text scoreText;

    public Text restartText;
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

        restartText.text = "Score: " + score;

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerCollided()
    {
        gameOver = true;
        RestartScreen();
    }

    

    public void PlayerStartedGame()
    {
        playerActive = true;
    }

    public void EnterGame()
    {
        audioSource.PlayOneShot (buttonPressed);
        mainMenu.SetActive(false);
        gameStarted = true;
        mainCam.enabled = mainCam.enabled;
        //resetCam.enabled = !resetCam.enabled;
    }

    public int AddPoint()
    {
        score++;
        scoreText.text = "Score: " + score;
        restartText.text = "Score: " + score;
        return score;
    }

    public void RestartScreen()
    {
        //if (gameOver == true)
        //{
           // mainCam.enabled = false;
            //resetCam.enabled = true;
            mainCam.enabled = !mainCam.enabled;
            resetCam.enabled = resetCam.enabled;
            gameOver = false;

        //}
    }
}
