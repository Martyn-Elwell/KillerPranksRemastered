using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Inventory playerInventory;
    public UIHandler UI;

    [SerializeField] private float raycastDistance = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractionUI();
    }

    private void InteractionUI()
    {
        // Check for the raycast hit without pressing the key to show the interaction text
        Ray rayForText = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitForText;

        if (Physics.Raycast(rayForText, out hitForText, raycastDistance))
        {
            // Check if the hit object has a script with the ItemPickup component
            IPickupable pickupable = hitForText.collider.GetComponent<IPickupable>();
            IInteractable interactable = hitForText.collider.GetComponent<IInteractable>();
            if (pickupable != null)
            {
                UI.PickupText(true);

            }
            else if (interactable != null)
            {
                UI.InteractText(true);
            }
            else
            {
                UI.HideInteractiveText();
            }
        }
        else
        {
            UI.HideInteractiveText();
        }
    }

    public void Interact()
    {
        
    }
}
