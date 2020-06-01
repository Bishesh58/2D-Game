using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{

    private List<items> itemList;
    private Action<items> useItemAction;
    public InventorySlot[] inventorySlotArray; 

    //creating event handler when item is being changed on the inventory
    public event EventHandler  OnItemListChange;

    public Inventory(Action<items> useItemAction, int inventorySlotCount)
    {
        this.useItemAction = useItemAction; 
        itemList = new List<items>(); 

        //setting up inventory arry
        inventorySlotArray = new InventorySlot[inventorySlotCount];
        for (int i = 0; i < inventorySlotCount; i++)
        {
            inventorySlotArray[i] = new InventorySlot(i);
        }

        //adding some of the items into the player inventory by default


        addItem(new items { itemType = items.ItemType.soil, amount = 1 });
        //addItem(new items { itemType = items.ItemType.leaves, amount = 1 });
       // addItem(new items { itemType = items.ItemType.vege1, amount = 1 });
        //addItem(new items { itemType = items.ItemType.meat, amount = 1 });
       // addItem(new items { itemType = items.ItemType.vege2, amount = 1 });
        addItem(new items { itemType = items.ItemType.branches, amount = 1 });
        addItem(new items { itemType = items.ItemType.smallStones, amount = 1 });
        addItem(new items { itemType = items.ItemType.largeStones, amount = 1 });
        addItem(new items { itemType = items.ItemType.fire, amount = 1 });
    }

   
    //setting up empty inventory slots
    public InventorySlot GetEmptyInventorySlot()
    {
        foreach (InventorySlot inventorySlot in inventorySlotArray)
        {
            if (inventorySlot.IsEmpty())
            {
                return inventorySlot;
            }
        }
        Debug.LogError("Cannot find an empty InventorySlot!");
        return null;
    }

    //setting up inventory slot with item
    public InventorySlot GetInventorySlotWithItem(items item)
    {
        foreach (InventorySlot inventorySlot in inventorySlotArray)
        {
            if (inventorySlot.GetItem() == item)
            {
                return inventorySlot;
            }
        }
        Debug.LogError("Cannot find Item " + item + " in a InventorySlot!");
        return null;
    }

    //adding items into the inventory player and checking if it can be stack
    public void addItem(items item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;

            foreach (items inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
                GetEmptyInventorySlot().SetItem(item);
            }
        }
        else
        {
            itemList.Add(item);
            GetEmptyInventorySlot().SetItem(item);
        }
        OnItemListChange?.Invoke(this, EventArgs.Empty); // event is being fired
    }

    //exposing getters and setters
    public void AddItem(items item, InventorySlot inventorySlot)
    {
        itemList.Add(item);
        inventorySlot.SetItem(item);

        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }

    public List<items> GetItemList()
    {
        return itemList;
    }
    public void UseItem(items item)
    {
        useItemAction(item);
    }

    public InventorySlot[] GetInventorySlotArray()
    {
        return inventorySlotArray;
    }

    public class InventorySlot
    {

        private int index;
        private items item;

        public InventorySlot(int index)
        {
            this.index = index;
        }

        public items GetItem()
        {
            return item;
        }

        public void SetItem(items item)
        {
            this.item = item;
        }

        public void RemoveItem()
        {
            item = null;
        }

        public bool IsEmpty()
        {
            return item == null;
        }

    }



}
  

