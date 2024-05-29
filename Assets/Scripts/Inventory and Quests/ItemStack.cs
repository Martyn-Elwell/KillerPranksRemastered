using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStack
{
    public string InspectorName;
    public ItemData item;
    public int quantity = 1;

    public ItemStack(ItemData data)
    {
        InspectorName = data.itemDescription;
        item = data;
        quantity = 1;
    }
}
