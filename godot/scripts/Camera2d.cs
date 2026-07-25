using Godot;
using System;
using GodotStringIntercept;

public partial class Camera2d : Camera2D
{
	public static Camera2d Instance { get; private set; }
	public double shakeIntensity = 0.0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		Position = new Vector2(960, 540);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 newOffset;
		newOffset.X = (float)GD.RandRange(0, shakeIntensity);
		newOffset.Y = (float)GD.RandRange(0, shakeIntensity);
		this.Offset = newOffset;
	}

	public Tween MoveCamera(float finalX) { 
		//Make a tween in the current tree, tween the camera, then return the tween to use the signal later
		Tween tween = GetTree().CreateTween();
		tween.SetProcessMode(Tween.TweenProcessMode.Physics);
		tween.TweenProperty(this, "position:x".AsNodePath(), finalX, 1.5);
		return tween;
	}
}
