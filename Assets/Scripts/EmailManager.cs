using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailManager : MonoBehaviour
{
    [SerializeField] private List<EmailScriptableObject> emailScriptableObject = null;
    [SerializeField] private List<Button> emailNotifications = null;

    [SerializeField] private Text targetNameText = null;
    [SerializeField] private Text floorNameText = null;
    [SerializeField] private Text prankNameText = null;
    [SerializeField] private List<Text> senderNameText = null;
    [SerializeField] private List<Text> dateNameText = null;

    [SerializeField] private GameObject emailPopupCanvas = null;
    [SerializeField] private GameObject desktopDisplay = null;
    [SerializeField] private GameObject emailDisplay = null;
    [SerializeField] private GameObject emailButton = null;

    [SerializeField] private int num = 0;

    // Start is called before the first frame update
    private void Start()
    {
        senderNameText[0].text = emailScriptableObject[0].sender;
        senderNameText[1].text = emailScriptableObject[1].sender;
        dateNameText[0].text = emailScriptableObject[0].date;
        dateNameText[1].text = emailScriptableObject[1].date;
        foreach (Button email in emailNotifications)
        {
            email.onClick.AddListener(() => InboxSelection(email));
            Debug.Log(email);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        switch (num)
        {
            case -1:
                num++;
                break;
            case 0:
                targetNameText.text = emailScriptableObject[0].target;
                floorNameText.text = emailScriptableObject[0].floor;
                prankNameText.text = emailScriptableObject[0].prank;
                break;
            case 1:
                targetNameText.text = emailScriptableObject[1].target;
                floorNameText.text = emailScriptableObject[1].floor;
                prankNameText.text = emailScriptableObject[1].prank;
                break;
            case 2:
                num--;
                break;
            default:
                Debug.Log("Unknown Data");
                break;
        }
    }

    private void InboxSelection(Button clickButton)
    {
        if (clickButton == emailNotifications[0])
        {
            num = 0;
        }
        else if (clickButton == emailNotifications[1])
        {
            num = 1;
        }
        
    }

    public void ForwardArrow()
    {
        num++;
    }

    public void BackwardArrow()
    {
        num--;
    }

    public void GoToEmailDisplay()
    {
        emailDisplay.SetActive(true);
        emailButton.gameObject.GetComponent<Button>().enabled = false;
    }

    public void GoToEmailPopup()
    {
        emailPopupCanvas.SetActive(true);
        emailDisplay.SetActive(false);
    }

    public void ExitButtonToDesktop()
    {
        emailPopupCanvas.SetActive(false);
        emailDisplay.SetActive(false);
        desktopDisplay.SetActive(true);
        emailButton.gameObject.GetComponent<Button>().enabled = true;

    }
    public void ExitButtonToEmailDisplay()
    {
        emailPopupCanvas.SetActive(false);
        emailDisplay.SetActive(true);
    }

    public void BackToInbox()
    {
        emailPopupCanvas.SetActive(false);
        emailDisplay.SetActive(true);
    }
}
