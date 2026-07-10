using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerInventory : Node
{


    public static PlayerInventory Instance { get; private set; }
    public List<InventoryItem> inventoryItems;

	public override void _EnterTree()
	{
		if (Instance != null && Instance != this)
		{
			GD.PushWarning("Multiple DialogueBoxUI instances found. Replacing singleton instance.");
		}

		Instance = this;
	}

	public override void _ExitTree()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

    public override void _Ready()
    {
        inventoryItems = new();
    }

    public void AddItem()
    {
        
    }

    public void RemoveItem()
    {
        
    }
    
    public bool HasItem(string id)
    {
        bool found = false;

        foreach (InventoryItem item in inventoryItems)
        {
            if (item.itemID == id) found = true;   
        }

        return found;
    }
}
