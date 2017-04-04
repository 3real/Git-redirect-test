using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class player : MonoBehaviour {

    [SerializeField]    private float jumpForce = 100f;
    [SerializeField]    private AudioClip sfxJump;
    [SerializeField]    private AudioClip sfxDeath;

    private Animator anim;
    private Rigidbody rigidBody;
    private bool jump = false;
    private AudioSource audioSource;

    private void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!gamemanager.instance.GameOver && gamemanager.instance.GameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gamemanager.instance.PlayerStartedGame();
                rigidBody.useGravity = true;
                anim.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                jump = true;
            }
        }
  	}

    private void FixedUpdate()
    {
        if (jump == true)
        {
            jump = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            rigidBody.AddForce(new Vector2(-100, -20), ForceMode.Impulse);
            rigidBody.detectCollisions = false;
            audioSource.PlayOneShot (sfxDeath);
            gamemanager.instance.PlayerCollided();
        }
    }
}
