using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    GameObject player1text;
    GameObject player2text;
    public BallScript ball;

    void Start()
    {
        player1text = GameObject.Find("Player1Score");
        player2text = GameObject.Find("Player2Score");
    }

    private void Reset()
    { 
        player1text.GetComponent<Text>().color = Color.white;
        player2text.GetComponent<Text>().color = Color.white;
    }

    // Powerup ideas:
    // - increase paddle size if score reaches 7.
    // - make ball speed really fast when score reaches 9.
    void OnTriggerEnter(Collider other)
    {
        // Power-up: double speed when score is 9.
        if (player1Score == 8)
        {
            ball.speed *= 2;
        }

        if (player2Score == 8)
        {
            ball.speed *= 2;
        }

        // Goals set as triggers.
        // If other goes through goal,
        // player score++;
        // output to console player score;
        if (other.name == "Player1Goal")
        {
            // If ball goes in player 1 goal,
            // player one score increases by 1.
            ++player1Score;
            // Sets the score text to the value of the score int.
            // Converts int to string.
            player1text.GetComponent<Text>().text = player1Score.ToString();
            Debug.Log($"Player 1 scored! P1: {player1Score}, P2: {player2Score}");
        }
        else
        {
            // Otherwise, if the ball goes in player 2 goal,
            // player two score increases by 1.
            ++player2Score;
            // Sets the score text to the value of the score int.
            // Converts int to string.
            player2text.GetComponent<Text>().text = player2Score.ToString();
            Debug.Log($"Player 2 scored! P1: {player1Score}, P2: {player2Score}");
        }

        if (player1Score == 10)
        {
            Debug.Log("One more point to win, Player 1!");
            player1text.GetComponent<Text>().color = Color.red;
        }
        
        if (player2Score == 10)
        {
            Debug.Log("One more point to win, Player 2!");
            player2text.GetComponent<Text>().color = Color.red;
        }
        
        // If 11 points,
        // print Game Over, Player whichever wins;
        // reset scores;
        //Debug.Log($"{other.name} landed in {this.name}");
        if (player1Score == 11)
        {
            Reset();
            Debug.Log($"Game Over. Player 1 wins! P1: {player1Score = 0}, P2: {player2Score = 0}");
            player1text.GetComponent<Text>().text = player1Score.ToString();
            player2text.GetComponent<Text>().text = player2Score.ToString();
        }
        else if (player2Score == 11)
        {
            Reset();
            Debug.Log($"Game Over. Player 2 wins! P1: {player1Score = 0}, P2: {player2Score = 0}");
            player1text.GetComponent<Text>().text = player1Score.ToString();
            player2text.GetComponent<Text>().text = player2Score.ToString();
        }
    }
}
