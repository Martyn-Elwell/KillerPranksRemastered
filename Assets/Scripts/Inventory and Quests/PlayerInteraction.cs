using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Inventory playerInventory;
    private UIHandler UI;

    [SerializeField] private float raycastDistance = 3f;

    void Start()
    {
        playerInventory = GetComponent<Inventory>();
        UI = GetComponentInChildren<UIHandler>();
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
                UI.PickupText(true, hitForText.collider.GetComponent<Item>().itemData.Icon);

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
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Pickup able object
            IPickupable pickupable = hit.collider.GetComponent<IPickupable>();
            if (pickupable != null)
            {
                pickupable.Pickup();

                ItemData item = hit.collider.GetComponent<Item>().itemData;
                if (item != null)
                {
                    PickUpItem(item);
                }
            }

            // InteractableObject
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }

        }
    }

    public void PickUpItem(ItemData item)
    {
        playerInventory.AddItem(item);
    }
}
