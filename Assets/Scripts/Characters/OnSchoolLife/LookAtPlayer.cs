using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        // Find the player object (you can replace "Player" with your player's tag or use a different method)
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Make the object look at the player
            transform.LookAt(player);

            // Lock the y-rotation to keep it constant
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}
