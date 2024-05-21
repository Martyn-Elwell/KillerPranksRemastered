using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailManager : MonoBehaviour
{
    [SerializeField] private List<EmailScriptableObject> emailScriptableObject;

    [SerializeField] private Text targetNameText;
    [SerializeField] private Text floorNameText;
    [SerializeField] private Text prankNameText;

    [SerializeField] private int num;

    // Start is called before the first frame update
    private void Start()
    {
        targetNameText.text = emailScriptableObject[0].target;
        floorNameText.text = emailScriptableObject[0].floor;
        prankNameText.text = emailScriptableObject[0].prank;
    }

    // Update is called once per frame
    private void Update()
    {
        switch(num)
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
            default:
                Debug.Log("Unknown Data");
                break;

        }
    }

    public void ForwardArrow()
    {
        Debug.Log("Forward arrow pressed");
        num++;
    }

    public void BackwardArrow()
    {
        Debug.Log("Back arrow pressed");
        num--;
    }
}
