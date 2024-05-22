using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using Text = TMPro.TextMeshProUGUI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Text interactiveText;
    [SerializeField] private Image interactiveImage;
    [SerializeField] private Text popupText;
    [SerializeField] private Image popupImage;

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
            if (sprite != null)
            {
                interactiveImage.gameObject.SetActive(true);
                interactiveImage.sprite = sprite;
            }
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

    public void PickupNotification(ItemData item)
    {
        //Add some tweening here
        //Pop up notifictation
        popupImage.gameObject.SetActive(true);
        popupText.gameObject.SetActive(true);
        popupImage.sprite = item.Icon;
        popupText.text = item.itemDescription;
        StartCoroutine(timerCoroutine());
    }

    public void HideInteractiveText()
    {
        interactiveText.gameObject.SetActive(false);
        interactiveImage.gameObject.SetActive(false);
    }


    private IEnumerator timerCoroutine()
    {

        yield return new WaitForSeconds(2f);
        popupText.text = "";
        popupImage.gameObject.SetActive(false);
        popupText.gameObject.SetActive(false);
    }
}
