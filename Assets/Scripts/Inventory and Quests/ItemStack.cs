using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStack
{
    [HideInInspector]public string InspectorName;
    public ItemData item;
    public int quantity;

    public ItemStack(ItemData data)
    {
        InspectorName = data.itemDescription;
        item = data;
        quantity = 1;
    }
}
