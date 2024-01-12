using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] Item item;

    public void Interact(GameObject interacter)
    {
        Inventory inventory = interacter.GetComponent<Inventory>();
        inventory.Set(item);
    }
}
