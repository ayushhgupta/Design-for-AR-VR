using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource dieSound;

    void Start()
    {
        gameObject.name = "Jack The Amazing Bird";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
       
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsAlive = false;
        dieSound.Play();
        logic.gameOver();
    }
}
