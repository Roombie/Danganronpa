using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    [SerializeField] InventoryPanel inventoryPanel;
    [SerializeField] ItemCollection collection;

    // Start is called before the first frame update
    void Start()
    {
        collection.Init();
        inventoryPanel.Set(collection);
    }

    public void Set(Item item, bool set = true)
    {
        collection.Set(item, set);
    }
}
