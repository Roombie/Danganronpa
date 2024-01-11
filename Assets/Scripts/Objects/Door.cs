using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DoorType
{
    Transition,
    Scene,
    Closed
}

public class Door : MonoBehaviour, IInteractable
{
   [SerializeField] DoorType doorType;
   [SerializeField] Transform destination;
   [SerializeField] string sceneDestinationName;

    public void Interact(GameObject interactor)
    {
        Debug.Log("Door Interacted!");

        switch (doorType)
        {
            case DoorType.Transition:
                interactor.transform.position = destination.transform.position;
                break;
            case DoorType.Scene:
                SceneManager.LoadScene(sceneDestinationName);
                break;
            case DoorType.Closed:
                break;
        }     
    }

    private void OnDrawGizmos()
    {
        if(doorType == DoorType.Transition && destination != null) {
            Debug.DrawLine(transform.position, destination.position);
        } 
    }
}
