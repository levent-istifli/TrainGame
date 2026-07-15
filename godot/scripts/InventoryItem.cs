using Godot;
using System;

[GlobalClass]
public partial class InventoryItem : Resource
{
	[Export] public Texture2D sprite;
	[Export] public string itemID;
}
