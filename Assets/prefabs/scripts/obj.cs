using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj : MonoBehaviour {

    [SerializeField]  private float objectSpeed = 10;
    [SerializeField]  private float resetPosition = -33f;
    [SerializeField]  private float startPosition = 69.5f;
    
	// Use this for initialization
	void Start () {
		
	}

    public void Respawn()
    {
        Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
        transform.position = newPos;
    }

    // Update is called once per frame
    protected virtual void Update () {


   

    if (!gamemanager.instance.GameOver)
        {
            transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

            if (transform.localPosition.x <= resetPosition)
            {
                Respawn();

            }
        }
    
	}
}
