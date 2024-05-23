using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockCutscene : MonoBehaviour
{
    public void LockCursor(bool LockValue)
    {
        if (LockValue == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
