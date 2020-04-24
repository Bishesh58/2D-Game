using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public items items;  // field

    
    private void Start()
    {
        ItemWorld.spawnItemWorld(transform.position, items);
        Destroy(gameObject);
    }
}
