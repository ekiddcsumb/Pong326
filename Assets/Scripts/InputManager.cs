using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    

    private GameObject ball;
    private GameObject goal1;
    private GameObject goal2;

    public GameObject player1ScoreText;
    public GameObject player2ScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        goal1 = GameObject.FindGameObjectWithTag("Player1Goal");
        goal2 = GameObject.FindGameObjectWithTag("Player2Goal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
