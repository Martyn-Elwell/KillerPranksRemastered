using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputSystem inputSystem;

    // Start is called before the first frame update
    private void Awake()
    {
        inputSystem = new InputSystem();    
    }

    private void OnEnable()
    {
        inputSystem.Enable();
        inputSystem.Player.Movement.performed += Movement_performed;
    }

    private void Movement_performed(InputAction.CallbackContext obj)
    {
        obj.ReadValue<Vector2>();
        Debug.Log(obj.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        inputSystem.Disable();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
