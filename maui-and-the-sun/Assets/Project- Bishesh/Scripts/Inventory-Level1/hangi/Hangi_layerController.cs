using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangi_layerController : MonoBehaviour
{
    public static int checkmarkCount = 0;
    public GameObject MessageBox;
    public GameObject Inventory;
    public GameObject Frame;




    private void Update()
    {
        LayersCompleted();
    }
    public void LayersCompleted()
    {
        if (checkmarkCount == 12)
        {
            StartCoroutine(RemoveAfterSeconds(3, gameObject));
            MessageBox.gameObject.SetActive(true);
            Inventory.gameObject.SetActive(false);
            Frame.gameObject.SetActive(false);
        }
    }
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(3);
        obj.SetActive(false);
    }


}
