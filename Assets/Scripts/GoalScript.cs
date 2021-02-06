using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other )
        {
            
        }
        Debug.Log($"{other.name} landed in {this.name}");
    }
}
