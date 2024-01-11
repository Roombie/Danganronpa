using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable // Once is referenced, it must have the same methods referenced
{
    void Interact(GameObject interactor);
}

public class Interactable : MonoBehaviour, IInteractable
{
    public void Interact(GameObject interactor)
    {
        Debug.Log("Test!");
    }
}
