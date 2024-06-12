using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact();
    public void Interact(GameObject player);

    public void Outline(bool active);
}
