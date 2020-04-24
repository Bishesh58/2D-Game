using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrigerInventory : MonoBehaviour
{
    public GameObject Maui;
    public GameObject arrow;
    public GameObject messagebox;

  
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ch-Maui")
        {
            Destroy(gameObject);
            Destroy(arrow);
            messagebox.gameObject.SetActive(true);
            Maui.GetComponent<Rigidbody2D>().isKinematic = true;
            Maui.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

        } 
    }
   

   
}
