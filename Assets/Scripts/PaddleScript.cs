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
	public float impulseStrength = 1f;

    private float movement;
    
    // Start is called before the first frame update
    // void Start()
    // {
    //     Nothing is happening to paddles at start.
    // }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
			// Player 1 uses info from Vertical Input Manager setting.
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
			// Player 1 uses info from Vertical2 Input Manager setting.
            movement = Input.GetAxisRaw("Vertical2");
        }
			// Velocity of the rigid body element (paddles) is determined by which player is being activated
			// and the speed value that is declared.
			// Uses Vector3 (3D) and only moving on the Z axis.
        rb.velocity = new Vector3(0, 0, movement * speed);
    }

void OnCollisionEnter(Collision collision)
  {
    Debug.Log($"{this.name} collided with the {collision.gameObject.name}");
    Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
    rb.AddForce((transform.up * impulseStrength), ForceMode.Impulse);
  }
}
