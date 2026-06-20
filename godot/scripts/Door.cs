using Godot;
using GodotStringIntercept;
using System;
using System.Reflection.Metadata.Ecma335;

[GlobalClass]
public partial class Door : Node2D
{
	[Export] public string destination_level_tag;
	[Export] public string destination_door_tag;
	[Export] public string spawn_direction = "right";
	public Marker2D spawn_point;

	public override void _Ready()
	{
		spawn_point = GetNode<Marker2D>("Spawn");
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is PlayerNew)
		{
			NavigationManager.Instance.goToLevel(destination_level_tag, destination_door_tag);
		}
	}
}
