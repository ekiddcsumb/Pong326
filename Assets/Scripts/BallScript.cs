using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Ball speed.
    public float speed;
    // Reference to ball's rigid body element.
    public Rigidbody rb;
    // public Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        // Ball must launch in either the left or right direction at random.
        Launch();
    }

    // Update is called once per frame
    void Update()
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
        Reset();
        Launch();
    }

    private void Reset()
    {
        // Sets the ball back to center.
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }
}
