using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerEventManager : MonoBehaviour
{
    private PlayerControls playerControls = null;

    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject displayCamera;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerControls = new PlayerControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //playerControls.Enable();
    }

    private void InteractPerformed(InputAction.CallbackContext obj)
    {
        playerCamera.SetActive(false);
        displayCamera.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Triggered");
            //playerControls.Enable();
            playerControls.Player.Interact.performed += InteractPerformed;

            if (playerControls.Player.Interact.triggered)
            {
                Destroy(player);
            }
        }
    }
}
