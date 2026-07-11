using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerInventory : Node
{

    [Export] InventoryItem[] itemPool;
    [Export] public HBoxContainer itemUIGrid;
    [Export] public PackedScene testIcon;
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
        AddItem("test");
    }

    public void AddItem(string id)
    {
        InventoryItem item = Array.Find(
            itemPool,
            poolItem => poolItem != null && poolItem.itemID == id
        );

        TextureRect iconObj = testIcon.Instantiate<TextureRect>();

        if (item == null)
        {
            GD.PushWarning($"Inventory item with ID '{id}' was not found.");
            return;
        }

        iconObj.Texture = item.sprite;
        itemUIGrid.AddChild(iconObj);
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
