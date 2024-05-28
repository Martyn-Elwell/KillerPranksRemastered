using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<ItemStack> items = new List<ItemStack>();
    public List<ItemStack> tools = new List<ItemStack>();


    public void AddItem(ItemData item)
    {
        // Add to tool bar
        if (item.tool == true)
        {
            if (item.doesStack)
            {
                ItemStack existingItem = tools.Find(i => i.item == item);

                if (existingItem != null)
                {
                    existingItem.quantity += 1;
                }
                else
                {
                    ItemStack newitem = new ItemStack(item);
                    tools.Add(newitem);
                }
            }
            else
            {
                ItemStack existingItem = tools.Find(i => i.item == item);

                if (existingItem == null)
                {
                    ItemStack newitem = new ItemStack(item);
                    tools.Add(newitem);
                }
            }
        }
        // Add to Item Inventory
        else
        {
            // Adds Item from Inventory
            ItemStack existingItem = items.Find(i => i.item == item);

            if (existingItem != null)
            {
                existingItem.quantity += 1;
            }
            else
            {
                ItemStack newitem = new ItemStack(item);
                items.Add(newitem);
            }
        }
        
    }

    public bool SearchInventory(ItemData item)
    {
        foreach (ItemStack itemInInv in items)
        {
            if (itemInInv.item == item)
            {
                return true;
            }
        }
        return false;
    }
}
