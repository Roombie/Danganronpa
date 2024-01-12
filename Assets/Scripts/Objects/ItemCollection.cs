using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public bool owned;
    public bool onStart;
}

[CreateAssetMenu(menuName = "Data/Collection")]
public class ItemCollection : ScriptableObject
{
    public List<ItemSlot> itemSlots;
    
    public void Init()
    {
        for(int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].owned = itemSlots[i].onStart;
        }
    }

    public void Set(Item item, bool set)
    {
        ItemSlot itemSlot = itemSlots.Find(x => x.item == item);
        
        if(itemSlot != null) {
            itemSlot.owned = set;
        } else {
            Debug.Log("No item of this type is present in this collection: " + item.Name);
        }
    }
}
