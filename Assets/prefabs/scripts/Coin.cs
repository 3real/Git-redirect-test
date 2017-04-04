using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Coin : obj {

    [SerializeField]    Vector3 topPosition;
    [SerializeField]    Vector3 bottomPosition;
    [SerializeField]    float speed;
    [SerializeField]    private float rotationalSpeed = 10f;
    [SerializeField]    private AudioClip sfxCoin;

    public gamemanager coinScore;

    private AudioSource audioSource;

    private void Awake()
    {
        Assert.IsNotNull(sfxCoin);
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Move(bottomPosition));
        audioSource = GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        if (gamemanager.instance.PlayerActive)

        { base.Update();}
        transform.Rotate(rotationalSpeed * Time.deltaTime,0,0);
    }

    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)

        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * Time.deltaTime * speed;

            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine(Move(newTarget));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            coinScore.AddPoint();
            audioSource.PlayOneShot(sfxCoin);
            Respawn();
        }
            
    }
}
