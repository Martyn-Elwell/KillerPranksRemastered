using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public int ID;
    public string itemName;
    public string itemDescription;
    public GameObject prefab;
    public Sprite Icon;
    public bool contraband;
}
