using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemWorld : MonoBehaviour
{
    

    public static ItemWorld spawnItemWorld(Vector3 position, items items)
    {
       Transform transform =  Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(items);

        return itemWorld;
    }


    private items items;
    private SpriteRenderer spriteRender;
    


    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
       
    }


    public void SetItem(items items)
    {
        this.items = items;
        spriteRender.sprite = items.GetSprite();
      
    }

    public items GetItem()
    {
        return items;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
