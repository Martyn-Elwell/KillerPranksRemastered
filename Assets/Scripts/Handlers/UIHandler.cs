using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;
using Text = TMPro.TextMeshProUGUI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject ToolbarSlotPrefab;
    [SerializeField] private List<GameObject> Toolbar;
    private List<Sprite> visibleSprites;
    private Vector3 originPos = new Vector3(1850, -50, 0);
    private float toolbarMoveDistance = 110f;
    private bool toolbarIsMoving = false;
    private bool delayEnabled = false;
    [SerializeField] private float scrollDelay = 0.1f;

    [SerializeField] private Text interactiveText;
    [SerializeField] private Image interactiveImage;
    [SerializeField] private Text popupText;
    [SerializeField] private Image popupImage;

    private void Start()
    {
        HideInteractiveText();
        CreateToolbar();
    }
    private void CreateToolbar()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 pos = new Vector3(originPos.x, originPos.y + toolbarMoveDistance * i, 0);
            GameObject slot = Instantiate(ToolbarSlotPrefab, pos, Quaternion.identity, transform);
            slot.GetComponent<ToobarSlot>().AssignPostiion(i);
            Toolbar.Add(slot);
            
            
        }
    }
    private void Update()
    {

        //Testing remove later
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ScrollUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ScrollDown();
        }
    }

    public void ScrollUp()
    {
        if (delayEnabled) { return; }
        if (toolbarIsMoving)
        {
            foreach (GameObject slot in Toolbar)
            {
                slot.GetComponent<ToobarSlot>().InteruptAnimation();
            }
            toolbarIsMoving = false;
        }

        Vector3 pos = new Vector3(originPos.x, originPos.y + toolbarMoveDistance * -1, 0);
        GameObject newSlot = Instantiate(ToolbarSlotPrefab, pos, Quaternion.identity, transform);
        newSlot.GetComponent<ToobarSlot>().AssignPostiion(-1);
        Toolbar.Insert(0, newSlot);

        foreach (GameObject slot in Toolbar)
        {
            slot.GetComponent<ToobarSlot>().MoveUp();
        }

        GameObject lastSlot = Toolbar[Toolbar.Count - 1];
        Toolbar.RemoveAt(Toolbar.Count - 1);
        Destroy(lastSlot);

        toolbarIsMoving = true;
        delayEnabled = true;

        Invoke("CancelDelay", scrollDelay);

    }
    public void ScrollDown()
    {
        if (delayEnabled) { return; }
        if (toolbarIsMoving)
        {
            foreach (GameObject slot in Toolbar)
            {
                slot.GetComponent<ToobarSlot>().InteruptAnimation();
            }
            toolbarIsMoving = false;
        }

        Vector3 pos = new Vector3(originPos.x, originPos.y + toolbarMoveDistance * 5, 0);
        GameObject newSlot = Instantiate(ToolbarSlotPrefab, pos, Quaternion.identity, transform);
        newSlot.GetComponent<ToobarSlot>().AssignPostiion(5);
        Toolbar.Add(newSlot);

        foreach (GameObject slot in Toolbar)
        {
            slot.GetComponent<ToobarSlot>().MoveDown();
        }

        GameObject firstSlot = Toolbar[0];
        Toolbar.RemoveAt(0);
        Destroy(firstSlot);

        toolbarIsMoving = true;
        delayEnabled = true;

        Invoke("CancelDelay", scrollDelay);
    }

    public void CancelDelay()
    {
        delayEnabled = false;
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
