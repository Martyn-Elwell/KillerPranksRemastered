using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Text interactiveText;
    [SerializeField] private Image interactiveImage;

    private void Start()
    {
        HideInteractiveText();
    }
    public void PickupText(bool active, Sprite sprite)
    {
        
        if (active)
        {
            interactiveText.gameObject.SetActive(true);
            interactiveText.text = "Press E to Pickup";
            interactiveImage.gameObject.SetActive(true);
            interactiveImage.sprite = sprite;
        }
    }

    public void InteractText(bool active)
    {
        if (active)
        {
            interactiveText.gameObject.SetActive(true);
            interactiveText.text = "Press E to Interact";
        }
    }

    public void HideInteractiveText()
    {
        interactiveText.gameObject.SetActive(false);
        interactiveImage.gameObject.SetActive(false);
    }

}
