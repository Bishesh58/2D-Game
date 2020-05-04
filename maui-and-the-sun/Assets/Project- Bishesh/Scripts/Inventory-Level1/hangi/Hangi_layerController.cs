using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangi_layerController : MonoBehaviour
{
    public static int checkmarkCount = 0;
    public GameObject MessageBox;
    public GameObject Inventory;
    public GameObject Frame;



    //updating hangi layers as item are being dropped
    private void Update()
    {
        LayersCompleted();
    }

    //checking if player has completed making hangi
    public void LayersCompleted()
    {
        if (checkmarkCount == 12)
        {
            StartCoroutine(RemoveAfterSeconds(3, gameObject)); //removing hangi inventory after three second
            MessageBox.gameObject.SetActive(true);  //showing congratulation message box on completion of hangi
            Inventory.gameObject.SetActive(false); //removing inventory from the interface
            Frame.gameObject.SetActive(false); //removing hangi frames
        }
    }

    //method returnns after the given time
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(3);
        obj.SetActive(false);
    }


}
