using Godot;
using System;

public partial class BackButton : Button
{

	[Export] string destination_level_tag;
	[Export] string destination_door_tag;
	[Export] string spawn_direction = "right";
	public Marker2D spawn_point;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Pressed += OnButtonPressed;
	}

	private void OnButtonPressed()
	{
		NavigationManager.Instance.go_to_level(destination_level_tag, destination_door_tag);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
