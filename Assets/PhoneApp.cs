using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class PhoneApp : MonoBehaviour
{
    [Header("Buttons")]
    public List<GameObject> ContactButtons;
    public List<GameObject> VoicemailButtons;

    [Header("Caller ID")]
    public List<string> ContactName;
    public List <Texture> ContactImage; 
    public int CallerID; 

    [Header("UI")]
    public TMP_Text CallerName;
    public TMP_Text CallType; 
    public RawImage CallerPic;
    public bool IncomingCall;
    public bool OutgoingCall;
    

    [Header("Canvases")]
    public List<GameObject> Canvases;
    public GameObject Phonescreen; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (IncomingCall)
        {
            CallIncoming(); 
        }

        if (OutgoingCall)
        {
            CallOutgoing(); 
        }
    }

    public void CallIncoming()
    {
        CallType.SetText("INCOMING");
        IncomingCall = false; 
        foreach (GameObject gc in Canvases)
        {
            gc.SetActive(false);
        }
        Phonescreen.SetActive(true);
    }

    public void CallOutgoing()
    {
        
        CallType.SetText("CALLING...");
        OutgoingCall = false;
        foreach (GameObject gc in Canvases)
        {
            gc.SetActive(false);
        }
        Phonescreen.SetActive(true);
    }
}
