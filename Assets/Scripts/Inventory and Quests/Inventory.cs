using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    private UIHandler UI;
    public List<ItemStack> items = new List<ItemStack>();
    public List<ItemStack> tools = new List<ItemStack>();
    public int selectedToolIndex = 0;
    public ItemStack SelectedTool;
    private void Start()
    {
        UI = GetComponentInChildren<UIHandler>();
    }
    public void AddItem(ItemData item)
    {
        // Add to tool bar
        if (item.tool == true)
        {
            if (tools.Count == 0)
            {
                ItemStack newitem = new ItemStack(item);
                tools.Add(newitem);
                AddFirstTool();
            }
            else if (item.doesStack)
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

    public void AddFirstTool()
    {
        selectedToolIndex = 0;
        SelectedTool = tools[0];
    }

    public void NextTool()
    {
        if (tools.Count <= 0) { return; }
        selectedToolIndex++;
        if (selectedToolIndex > tools.Count - 1)
        {
            selectedToolIndex = 0;
        }
        SelectedTool = tools[selectedToolIndex];
        UI.ScrollUp();
    }

    public void PreviousTool()
    {
        if(tools.Count <= 0) { return; }
        selectedToolIndex--;
        if (selectedToolIndex < 0)
        {
            selectedToolIndex = tools.Count - 1;
        }
        SelectedTool = tools[selectedToolIndex];
        UI.ScrollDown();
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
