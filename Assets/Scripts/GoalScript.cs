using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // if other goes through goal,
        // player score++;
        // output to console player score;
        
        // if 11 points,
        // print Game Over, Player whichever wins;
        // reset scores;
        Debug.Log($"{other.name} landed in {this.name}");
    }
}
