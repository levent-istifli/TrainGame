using Godot;
using GodotStringIntercept;
using System;
using System.Reflection.Metadata.Ecma335;

[GlobalClass]
public partial class Door : Node2D
{
	[Export] public string destination_level_tag;
	[Export] public string destination_door_tag;
	[Export] public PackedScene nextLevel;
	[Export] public Marker2D spawn_point;

	private void OnBodyEntered(Node2D body)
	{

		if (body is PlayerNew player)
		{
			Node2D nextLevel = GetParent().GetParent().GetParent().GetNode<Node2D>(destination_level_tag);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
			NavigationManager.Instance.goToLevel(destination_level_tag, destination_door_tag, nextLevel, player);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
		}
	}
}
