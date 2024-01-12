using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    InventoryPanel panel;
    ItemSlot item;

    public void Set(ItemSlot itemSlot, InventoryPanel panel)
    {
        this.panel = panel;
        gameObject.SetActive(true);
        item = itemSlot;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.Name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        panel.Show(item);
    }
}
