using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContactText : MonoBehaviour
{
    [Header("CallerID")]
    public Texture ContactImage;
    public string Name;

    [Header("ButtonSettings")]
    public Button Button;
    public RawImage ButtonImage;
    public TMP_Text ButtonText;

    // Start is called before the first frame update
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


    }
}
