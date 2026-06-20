using Godot;
using System;

public partial class Camera2d : Camera2D
{
	public static Camera2d Instance { get; private set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		GD.Print("Camera Pos: ", Position);
		Position = new Vector2(960, 540);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void MoveCamera(float finalX) { 
		GetTree().CreateTween().TweenProperty(this, "position:x", finalX, 0.5);
	}
}
