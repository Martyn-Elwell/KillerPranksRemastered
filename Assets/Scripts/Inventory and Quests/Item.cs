using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickupable
{
    public ItemData itemData;
    public void Pickup()
    {
        Destroy(gameObject);
    }
}
