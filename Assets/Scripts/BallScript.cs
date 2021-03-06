using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum GameTag
{
    Wall,
    Paddle
}

[RequireComponent(typeof(AudioSource))]
public class BallScript : MonoBehaviour
{
    // Ball speed.
    public float speed;
    // Reference to ball's rigid body element.
    public Rigidbody rb;
    // Audio members:
    private AudioSource audioSource;
    public AudioClip paddleCollision;
    public AudioClip wallCollision;
    public float pitchIncrement = (float) .2;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Ball must launch in either the left or right direction at random.
        // 1 second delay.
        Invoke(nameof(Launch), 1);
    }

    private void FixedUpdate()
    {
        
    }

    private void Launch()
    {
        // Randomly sets x and z direction.
        // Either goes left or right, and up or down.
        // Ternary operators randomly set x/z to either -1 or 1.
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float z = Random.Range(0, 2) == 0 ? -1 : 1;
        // Speed * -1 or 1 in the x and z direction. No need for y direction.
        rb.velocity = new Vector3(speed * x, 0, speed * z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Restarts ball when it goes through a goal.
        Reset();
        // 1 second delay before relaunching.
        Invoke(nameof(Launch), 1);
    }

    public void Reset()
    {
        // Sets the ball back to center.
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        speed = 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Audio controls:
        audioSource.pitch = pitchIncrement * speed;
        
        if (collision.gameObject.CompareTag(GameTag.Paddle.ToString()))
        {
            audioSource.PlayOneShot(paddleCollision);
        }

        if (collision.gameObject.CompareTag(GameTag.Wall.ToString()))
        {
            audioSource.PlayOneShot(wallCollision);
        }
        
        // Sound alteration ideas:
        // - sound increases pitch when ball speed increases
        // - 
        
        // Controls for ball impact direction and color change:
        // float directionz = (rb.transform.position.z - collision.transform.position.z) + speed;
        // float directionx = (rb.transform.position.x - collision.transform.position.x) + speed;
        float xPosition = rb.position.x;
        float zPosition = rb.position.z;

        // float ballHeight = transform.position.z - collision.transform.position.z;
        // float maxHeight = collision.collider.bounds.extents.z;
        // float percentOfMax = ballHeight / maxHeight;
        

        switch (collision.gameObject.name)
        {
            // If ball hits paddle or wall,
            // go in opposite direction.
            // Also handles speed increase (by 2) when ball hits paddles.
            // Also changes ball color when colliding - for the "juice"
            case "Player1":
                rb.AddForce(transform.right * (speed+=2), ForceMode.Impulse);
                //rb.velocity = new Vector3(xPosition, 0, zPosition);
                GetComponent<Renderer>().material.color = Color.cyan;
                break;
            case "Player2":
                rb.AddForce(-transform.right * (speed+=2), ForceMode.Impulse);
                //rb.velocity = new Vector3(xPosition, 0, zPosition);
                GetComponent<Renderer>().material.color = Color.magenta;
                break;
            case "TopWall":
                //rb.AddForce(0, 0, -directionz, ForceMode.Impulse);
                rb.velocity = new Vector3(xPosition, 0, -zPosition);
                GetComponent<Renderer>().material.color = Color.green;
                break;
            case "BottomWall":
                //rb.AddForce(0, 0, directionz, ForceMode.Impulse);
                rb.velocity = new Vector3(xPosition, 0, -zPosition);
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }
    }
}
