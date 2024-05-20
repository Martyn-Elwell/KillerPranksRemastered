using UnityEngine;
using UnityEngine.UI;

public class EmailManager : MonoBehaviour
{
    [SerializeField] private EmailScriptableObject emailScriptableObject;

    [SerializeField] private Text targetNameText;
    [SerializeField] private Text floorNameText;
    [SerializeField] private Text prankNameText;

    // Start is called before the first frame update
    void Start()
    {
        targetNameText.text = emailScriptableObject.target;
        floorNameText.text = emailScriptableObject.floor;
        prankNameText.text = emailScriptableObject.prank;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
