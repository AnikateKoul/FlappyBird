using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float flapStrength = 10;
    public LogicScript logic;
    public bool isBirdAlive = true;
    public AudioSource gameSound;
    public AudioSource gameOverSound;
    public AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBirdAlive && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = Vector2.up * flapStrength;
            jumpSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isBirdAlive = false;
        gameSound.Stop();
        gameOverSound.Play();
    }

}
