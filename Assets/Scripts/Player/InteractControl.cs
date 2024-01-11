using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractControl : MonoBehaviour
{
    [SerializeField] float maxDistance = 2f;

    public void OnExamine(InputAction.CallbackContext context)
    {
        if (context.started) {
            CastRay();
        }
    }

    private void CastRay()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red, 1.0f);

        if (Physics.Raycast(ray, out hit, maxDistance)) {
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();
            if (interactable != null) {
                interactable.Interact(gameObject);
            }
        } 
    }
}
