using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    [SerializeField] private List<Light> lights;
    private bool active = true;
    public override void Interact()
    {
        active = !active;
        foreach (Light light in lights)
        {
            light.enabled = active;
        }
    }
}
