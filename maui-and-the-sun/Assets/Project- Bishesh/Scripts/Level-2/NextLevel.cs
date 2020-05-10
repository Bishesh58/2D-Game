using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject congratulationBox;
    public GameObject collectingWood;
    public GameObject missedToCollectWood;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ch-Maui")
        {
            if (collectingWood.gameObject.activeSelf)
            {
                missedToCollectWood.SetActive(true);
            }
            if (collectingWood.gameObject.activeSelf == false)
            {
                congratulationBox.gameObject.SetActive(true);
            }
           
        }
    }
}
