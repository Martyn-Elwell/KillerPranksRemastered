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
            IPrankable prankable = hitForText.collider.GetComponent<IPrankable>();
            if (!GetComponent<CharacterController>().enabled)
            {
                interactText.text = "";
                interactText.gameObject.SetActive(false);

            }
            else if (pickupable != null)
            {
                interactText.text = "Press " + pickupKey.ToString() + " to Pickup " + hitForText.collider.GetComponent<ItemPickup>().item.itemName;
                interactText.gameObject.SetActive(true);

            }
            else if (interactable != null)
            {
                interactText.text = "Press " + pickupKey.ToString() + " to Interact";
                interactText.gameObject.SetActive(true);
            }
            else if (prankable != null)
            {
                if (hitForText.collider.GetComponent<PrankLocation>().completed)
                {
                    interactText.text = "";
                    interactText.gameObject.SetActive(false);
                }
                else if (hitForText.collider.GetComponent<PrankLocation>().CheckPrerequisites(this.gameObject.GetComponent<Inventory>()))
                {
                    interactText.text = "Press " + pickupKey.ToString() + " to Prank";
                    interactText.gameObject.SetActive(true);
                }
                else
                {
                    interactText.text = "Complete the steps to prank";
                    interactText.gameObject.SetActive(true);
                }
            }
            else
            {
                // Hide the interaction text if not aiming at an item
                interactText.gameObject.SetActive(false);
            }
        }
        else
        {
            // Hide the interaction text if not aiming at anything
            interactText.gameObject.SetActive(false);
        }
    }
}
