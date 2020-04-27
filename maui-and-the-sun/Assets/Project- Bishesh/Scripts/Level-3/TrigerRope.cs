using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrigerRope : MonoBehaviour
{
    public GameObject maui;
    public GameObject Hint;
    public GameObject Ropebutton;
   

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ch-Maui")
        {
            Hint.SetActive(true);
            useRope.isReadyToUse = true;
            // maui.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }







}
