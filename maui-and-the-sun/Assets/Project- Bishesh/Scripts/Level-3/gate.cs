using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to handle the gate of the hut
public class gate : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ch-Maui")
        {
            gameObject.SetActive(false); //when player collides with the gate then it will open
        }
    }
}
