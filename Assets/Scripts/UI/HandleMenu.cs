using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HandleMenu : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] PlayerCamera playerCamera;
    [SerializeField] GameObject mainControlPanel;
    [SerializeField] List<GameObject> panels;

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(!ActiveCheck()) {
                OpenMainControlPanel();
            } else {
                CloseMainControlPanel();
            }
        } else {
            Debug.LogWarning("Invalid or null InputAction.CallbackContext in OnPause");
        }
    }

    bool ActiveCheck()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if (panels[i].activeInHierarchy == true)
            {
                return true;
            }
        }

        return false;
    }

    public void OpenMainControlPanel()
    {
        // Set the pause state to paused
        Time.timeScale = 0f;

        // Disable player movement and camera if they are available
        /*if (playerMovement == null) { playerMovement = GetComponent<PlayerMovement>(); }
        if (playerCamera == null) { playerCamera = GetComponent<PlayerCamera>(); }

        playerMovement.enabled = playerCamera.enabled = false;*/

        // Show the inventory panel
        mainControlPanel.SetActive(true);
    }

    public void CloseMainControlPanel()
    {
        // Set the pause state to unpaused
        Time.timeScale = 1f;

        // Enable player movement and camera if they are available
        /*if (playerMovement == null) { playerMovement = GetComponent<PlayerMovement>(); }
        if (playerCamera == null) { playerCamera = GetComponent<PlayerCamera>(); }

        playerMovement.enabled = playerCamera.enabled = true;*/

        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(false);
        }
    }
}
