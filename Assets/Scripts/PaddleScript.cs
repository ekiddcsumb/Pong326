using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
	// Player 1 will be left paddle.
    public bool isPlayer1;
	// Speed will determine how fast the paddles move.
    public float speed;
	// Need a reference to the rigid body elements.
    public Rigidbody rb;
    public GoalScript score;
    public GameObject player1;
    public GameObject player2;

    private Vector3 scale;
    private Vector3 position;

    private float movement;
    
    // Start is called before the first frame update
    // void Start()
    // {
    //     Nothing is happening to paddles at start.
    // }
    
    void FixedUpdate()
    {
	    scale = transform.localScale;
	    scale.z = 9;
	    // Increase paddle length if player scores 7.
	    if (score.player1Score >= 7)
	    {
		    player1.transform.localScale = scale;
	    }
	       
	    if (score.player2Score >= 7)
	    {
		    player2.transform.localScale = scale;
	    }
	    
	    // Checks is player 1 or player 2 paddle is being used.
	    // Key assignment from Input Manager.
	    // If player 1, use W and S keys.
	    // If player 2, use up and down keys.
	    movement = Input.GetAxisRaw(isPlayer1 ? "Vertical" : "Vertical2");
	    // Velocity of the rigid body element (paddles) is determined by which player is being activated
		// and the speed value that is declared.
		// Uses Vector3 (3D) and only moving on the Z axis.
        rb.velocity = new Vector3(0, 0, movement * speed);

    }

    private void OnCollisionEnter(Collision collision)
    {
	    // position = transform.position;
	    //
	    // if (collision.collider.name == "TopWall")
	    // {
		   //  position.z = (float) (position.z - 0.1);
		   //  player1.transform.position = position;
	    // }
	    
	    
	    
	    // More "juice"
	    GetComponent<Renderer>().material.color = collision.gameObject.name switch
	    {
		    "Ball" => Color.blue,
		    "TopWall" => Color.white,
		    "BottomWall" => Color.gray,
		    _ => GetComponent<Renderer>().material.color
	    };
    }
    
}
