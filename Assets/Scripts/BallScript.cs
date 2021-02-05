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
        Launch();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     
    // }

    private void Launch()
    {
        // 
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        float z = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(speed * x, speed * y, speed * z);
    }
}
