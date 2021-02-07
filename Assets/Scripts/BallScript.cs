using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Ball speed.
    public float speed;
    // Reference to ball's rigid body element.
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Ball must launch in either the left or right direction at random.
        // 1 second delay.
        Invoke("Launch", 1);
    }
    
    void FixedUpdate()
    {

    }

    private void Launch()
    {
        // Randomly sets x and z direction.
        // Either goes left or right, and up or down.
        // Ternary oporators randomly set x/z to either -1 or 1.
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float z = Random.Range(0, 2) == 0 ? -1 : 1;
        // Speed * -1 or 1 in the x and z direction. No need for y direction.
        rb.velocity = new Vector3(speed * x, 0, speed * z);
    }

    void OnTriggerEnter()
    {
        // Restarts ball when it goes through a goal.
        Reset();
        // 1 second delay before relaunching.
        Invoke("Launch", 1);
    }

    public void Reset()
    {
        // Sets the ball back to center.
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        speed = 5;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log($"{this.name} collided with the {collision.gameObject.name}");
        // If ball hits paddle,
        // increase ball speed by 2.
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            //Debug.Log(speed);
            this.speed+=2;
            //Debug.Log(speed);
        }
		
    }
}
