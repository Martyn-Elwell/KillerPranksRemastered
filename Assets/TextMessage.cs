using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMessage : MonoBehaviour
{
    // Start is called before the first frame update

    public string Message;
    public TMP_Text Text;
    void Start()
    {
        Text.SetText(Message.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
