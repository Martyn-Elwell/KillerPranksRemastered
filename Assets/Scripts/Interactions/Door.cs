using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private float openDuration = 1f;
    [SerializeField] private float openAngle = 85f;
    private Vector3 closedRotation;
    private bool open = false;
    public override void OnStart()
    {
        closedRotation = transform.localRotation.eulerAngles;
    }
    public override void Interact(GameObject Player)
    {
        open = !open;
        if (!open)
        {
            transform.DOLocalRotate(closedRotation, openDuration, RotateMode.Fast).SetEase(Ease.InOutCubic);
        }
        if (open)
        {
            Vector3 openRotation = closedRotation;
            if (CalculatePlayerRelativePosition(Player))
            {
                openRotation.y -= openAngle;
            }
            else
            {
                openRotation.y += openAngle;
            }
            transform.DOLocalRotate(openRotation, openDuration, RotateMode.Fast).SetEase(Ease.InOutCubic);
        }
    }

    public bool CalculatePlayerRelativePosition(GameObject player)
    {
        // Get the direction from the door to the player
        Vector3 toPlayer = player.transform.position - transform.position;

        // Project this direction onto the door's forward vector
        float dotProduct = Vector3.Dot(transform.forward, toPlayer);

        if (dotProduct > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
