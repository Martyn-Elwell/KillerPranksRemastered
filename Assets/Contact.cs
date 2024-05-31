using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Contact : MonoBehaviour
{
    [Header("CallerID")]
    public Texture ContactImage;
    public string Name;

    [Header("ButtonSettings")]
    public Button Button;
    public RawImage ButtonImage;
    public TMP_Text ButtonText;

    [Header("PhoneLocation")]
    public GameObject Contactsphone;
    public GameObject NPC;

    void Start()
    {
        Button.onClick.AddListener(ButtonClicked);
        ButtonText.SetText(Name.ToString());
        ButtonImage.texture = ContactImage; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClicked()
    {

        //Player Phone
        GetComponentInParent<PhoneApp>().CallerName.SetText(Name);
        GetComponentInParent<PhoneApp>().CallerPic.texture = ContactImage;
        GetComponentInParent<PhoneApp>().OutgoingCall = true; 

        //NPC Phone
        //RING NOISE
        //SET PLAYER TO GO TO PHONE


    }
}
