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
        inventoryItems.Add(item);
        itemUIGrid.AddChild(iconObj);
    }

    public void RemoveItem(string id)
{
    int itemIndex = inventoryItems.FindIndex(
        item => item != null && item.itemID == id
    );

    if (itemIndex == -1)
    {
        GD.PushWarning($"Inventory item with ID '{id}' was not found.");
        return;
    }

    inventoryItems.RemoveAt(itemIndex);

    if (itemIndex < itemUIGrid.GetChildCount())
    {
        Node icon = itemUIGrid.GetChild(itemIndex);
        itemUIGrid.RemoveChild(icon);
        icon.QueueFree();
    }
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
