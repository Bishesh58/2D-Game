using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemWorld : MonoBehaviour
{
    
    //spawning items into the scene with the help of pfItem
    public static ItemWorld spawnItemWorld(Vector3 position, items items)
    {
        //Instantiating pfItemWord
       Transform transform =  Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity); 

        //getting items from the class ItemWorld
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(items); //setting up item

        return itemWorld;
    }


    private items items;
    private SpriteRenderer spriteRender;
    


    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>(); //setting up SpriteRenderer
    }

    //getters and setters
    public void SetItem(items items)
    {
        this.items = items;
        spriteRender.sprite = items.GetSprite();
    }

    public items GetItem()
    {
        return items;
    }

    //destorying items after the player collects items from the scene
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
