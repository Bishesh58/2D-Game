using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryMe : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(RemoveAfterSeconds(15, gameObject));
        }

    }
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(15);
        Destroy(obj);
    }
}
