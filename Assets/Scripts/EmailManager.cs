using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailManager : MonoBehaviour
{
    [Header("Email Scriptable Object Data")]
    [SerializeField] private List<EmailScriptableObject> emailScriptableObject = null;

    [Header("Inbox Button Settings")]
    private List<Button> emailNotificationsList = null;
    [SerializeField] private List<Text> senderNameTextList = null;
    [SerializeField] private List<Text> dateNameTextList = null;
    [SerializeField] private GameObject unreadArea = null;
    [SerializeField] private GameObject readArea = null;
    [SerializeField] private GameObject unreadButton = null;
    [SerializeField] private GameObject readButton = null;
    [SerializeField] private GameObject content = null;

    [Header("Email Popup Settings")]
    [SerializeField] private Text targetNameText = null;
    [SerializeField] private Text floorNameText = null;
    [SerializeField] private Text prankNameText = null;

    [Header("Popup Canvases")]
    [SerializeField] private GameObject desktopDisplay = null;
    [SerializeField] private GameObject inboxDisplay = null;
    [SerializeField] private GameObject emailDisplay = null;
    [SerializeField] private GameObject cctvDisplay = null;

    [Header("Desktop Icons")]
    [SerializeField] private GameObject emailButton = null;
    [SerializeField] private GameObject cctvButton = null;

    [Header("Camera Lists")]
    [SerializeField] private List<GameObject> footageList = null;

    [Header("Prefabs")]
    [SerializeField] private GameObject emailButtonPrefab;

    private int currentDisplay = 0;

    // Start is called before the first frame update
    private void Start()
    {
        /// TEMP TEST WILL BE REMOVED ///
        //senderNameTextList[0].text = emailScriptableObject[0].sender;
        //senderNameTextList[1].text = emailScriptableObject[1].sender;
        //dateNameTextList[0].text = emailScriptableObject[0].date;
        //dateNameTextList[1].text = emailScriptableObject[1].date;
        ///

        for (int i = 0; i < 2; i++)
        {
            Instantiate(emailButtonPrefab, content.transform.position, Quaternion.identity, content.transform);
            emailNotificationsList.Add(emailButtonPrefab.GetComponent<Button>());
        }

        // Used to click on each inbox message individually
        foreach (Button email in emailNotificationsList)
        {
            email.onClick.AddListener(() => InboxSelection(email));
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Using the forward and back buttons displays different options in the emails
        SwitchBetweenPrankEmails();
        // Using the forward and back buttons displays different CCTV footage 
        SwitchBetweenCCTV();        
    }

    private void SwitchBetweenPrankEmails()
    {
        if (emailDisplay.activeInHierarchy == true)
        {
            switch (currentDisplay)
            {
                case -1:
                    currentDisplay++;
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
                    currentDisplay--;
                    break;
                default:
                    Debug.Log("Unknown Data");
                    break;
            }
        }
    }

    private void SwitchBetweenCCTV()
    {
        if (cctvDisplay.activeInHierarchy == true)
        {
            switch (currentDisplay)
            {
                case -1:
                    currentDisplay++;
                    break;
                case 0:
                    footageList[0].SetActive(true);
                    footageList[1].SetActive(false);
                    break;
                case 1:
                    footageList[0].SetActive(false);
                    footageList[1].SetActive(true);
                    break;
                case 2:
                    currentDisplay--;
                    break;
                default:
                    Debug.Log("Unknown Data");
                    break;
            }
        }
    }

    // Decided what inbox message matches with which email popup
    private void InboxSelection(Button clickButton)
    {
        if (clickButton == emailNotificationsList[0])
        {
            currentDisplay = 0;
        }
        else if (clickButton == emailNotificationsList[1])
        {
            currentDisplay = 1;
        }
        
    }

    public void ForwardArrow()
    {
        currentDisplay++;
    }

    public void BackwardArrow()
    {
        currentDisplay--;
    }

    public void GoToInboxDisplay()
    {
        inboxDisplay.SetActive(true);
        emailButton.gameObject.GetComponent<Button>().enabled = false;
        cctvButton.gameObject.GetComponent<Button>().enabled = false;
    }

    public void GoToCCTV()
    {
        cctvDisplay.SetActive(true);
        emailButton.gameObject.GetComponent<Button>().enabled = false;
        cctvButton.gameObject.GetComponent<Button>().enabled = false;
    }

    public void GoToEmailPopup()
    {
        inboxDisplay.SetActive(false);
        emailDisplay.SetActive(true);
    }

    public void ExitButtonToDesktop()
    {
        inboxDisplay.SetActive(false);
        emailDisplay.SetActive(false);
        cctvDisplay.SetActive(false);
        desktopDisplay.SetActive(true);
        unreadArea.SetActive(true);
        readArea.SetActive(false);
        emailButton.gameObject.GetComponent<Button>().enabled = true;
        cctvButton.gameObject.GetComponent<Button>().enabled = true;
        currentDisplay = 0;
        unreadButton.gameObject.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        readButton.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
    public void ExitButtonToEmailDisplay()
    {
        inboxDisplay.SetActive(false);
        emailDisplay.SetActive(true);
        currentDisplay = 0;
    }

    public void BackToInbox()
    {
        inboxDisplay.SetActive(true);
        emailDisplay.SetActive(false);
    }

    public void SwitchToReadTab()
    {
        unreadArea.SetActive(false);
        readArea.SetActive(true);
        readButton.gameObject.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        unreadButton.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void SwitchToUnreadTab()
    {
        unreadArea.SetActive(true);
        readArea.SetActive(false);
        unreadButton.gameObject.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        readButton.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
}
