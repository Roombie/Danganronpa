using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        // Move the GameObject to the specified camera position
        transform.position = cameraPosition.position;
    }
}
