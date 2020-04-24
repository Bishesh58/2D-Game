using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Transform pfUI_Item;
    public Inventory inventory; //ref
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");

        itemSlotTemplate.gameObject.SetActive(false);
    }
   

    public void SetInventory (Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
        inventory.OnItemListChange += Inventory_OnItemListChange;
    }

    private void Inventory_OnItemListChange(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;

        foreach (Inventory.InventorySlot inventorySlot in inventory.GetInventorySlotArray())
        {
            items items = inventorySlot.GetItem();
           RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            
            

            //TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            //if (items.amount>1)
            //{
            //    uiText.SetText(items.amount.ToString());
            //}
            //else
            //{
            //    uiText.SetText("");
            //}

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);

            if (!inventorySlot.IsEmpty())
            {
                // Not Empty, has Item
                Transform uiItemTransform = Instantiate(pfUI_Item, itemSlotContainer);
                uiItemTransform.GetComponent<RectTransform>().anchoredPosition = itemSlotRectTransform.anchoredPosition;
                UI_Item uiItem = uiItemTransform.GetComponent<UI_Item>();
                uiItem.SetItem(items);
                uiItem.SetSprite(items.GetSprite());
            }

            Inventory.InventorySlot tmpInventorySlot = inventorySlot;

            UI_ItemSlot uiItemSlot = itemSlotRectTransform.GetComponent<UI_ItemSlot>();
            uiItemSlot.SetOnDropAction(() => {
                // Dropped on this UI Item Slot
                items draggedItem = UI_ItemDrag.Instance.GetItem();
                inventory.AddItem(draggedItem, tmpInventorySlot);
            });

            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }

        }
    }


}
