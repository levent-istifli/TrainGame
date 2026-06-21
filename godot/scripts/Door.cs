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
	[Export] public Node2D currentLevel;
	public Marker2D spawn_point;

	public override void _Ready()
	{
		spawn_point = GetNode<Marker2D>("Spawn");
	}

	private void _on_body_entered(Node2D body)
	{
		//GD.Print("Door entered");
		//GD.Print(body.Name);

		if (body is PlayerNew player)
		{
			NavigationManager.Instance.goToLevel(destination_level_tag, destination_door_tag, currentLevel, player);
		}
	}
}
