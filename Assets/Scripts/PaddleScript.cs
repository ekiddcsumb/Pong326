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

    private float movement;
    
    // Start is called before the first frame update
    // void Start()
    // {
    //     Nothing is happening to paddles at start.
    // }
    
    void FixedUpdate()
    {
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
}
