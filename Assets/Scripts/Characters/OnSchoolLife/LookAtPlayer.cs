using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer sprRenderer;

    void Start()
    {
        // Find the player object (you can replace "Player" with your player's tag or use a different method)
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprRenderer = GetComponent<SpriteRenderer>();

        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Make the object look at the player
            transform.LookAt(player);

            // Lock the y-rotation to keep it constant
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            // Flip sprite issue so I flip X so it's true
            sprRenderer.flipX = true;

            /*
             // Calculate the rotation to look at the player
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0f; // Keep the rotation only in the horizontal plane
            Quaternion rotation = Quaternion.LookRotation(directionToPlayer);

            // Apply the rotation
            transform.rotation = rotation;
             */
        }
    }
}
