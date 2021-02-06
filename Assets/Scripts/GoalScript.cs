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
    //private Text text;

    void Start()
    {
        player1text = GameObject.Find("Player1Score");
        player2text = GameObject.Find("Player2Score");
    }
    void OnTriggerEnter(Collider other)
    {
        
        // if other goes through goal,
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
        
        // if 11 points,
        // print Game Over, Player whichever wins;
        // reset scores;
        //Debug.Log($"{other.name} landed in {this.name}");
        if (player1Score == 11)
        {
            Debug.Log($"Game Over. Player 1 wins! P1: {player1Score = 0}, P2: {player2Score = 0}");
            player1text.GetComponent<Text>().text = player1Score.ToString();
            player2text.GetComponent<Text>().text = player2Score.ToString();
        }
        else if (player2Score == 11)
        {
            Debug.Log($"Game Over. Player 2 wins! P1: {player1Score = 0}, P2: {player2Score = 0}");
            player1text.GetComponent<Text>().text = player1Score.ToString();
            player2text.GetComponent<Text>().text = player2Score.ToString();
        }
    }
}
