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

	public Tween MoveCamera(float finalX) { 
		//Make a tween in the current tree, tween the camera, then return the tween to use the signal later
		Tween tween = GetTree().CreateTween();
		tween.TweenProperty(this, "position:x", finalX, 1.5);
		return tween;
	}
}
