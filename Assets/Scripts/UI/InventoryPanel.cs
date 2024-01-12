using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] List<InventoryButton> inventoryButtons;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI description;

    public void Show(ItemSlot itemSlot)
    {
        description.text = itemSlot.item.Description;
        if(itemSlot.item.Picture != null)
        {
            image.sprite = itemSlot.item.Picture;
        }
    }

    public void Set(ItemCollection itemCollection)
    {
        for (int i = 0; i < inventoryButtons.Count; i++)
        {
            inventoryButtons[i].gameObject.SetActive(false);
        }

        // Ensure that the itemCollection has enough slots
        int itemCount = Mathf.Min(itemCollection.itemSlots.Count, inventoryButtons.Count);

        for (int i = 0; i < itemCount; i++)
        {
            // Check if the item is owned before attempting to set the button
            if (itemCollection.itemSlots[i].owned)
            {
                inventoryButtons[i].Set(itemCollection.itemSlots[i], this);
            }
        }
    }
}
