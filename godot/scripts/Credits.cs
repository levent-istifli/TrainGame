using Godot;
using GodotStringIntercept;
using System;

public partial class Credits : Control
{
	const float SCROLL_SPEED = 100;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// set the initial position of control node at bottom of the screen
		Position = new Vector2(Position.X, GetViewportRect().Size.Y);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// decrease Y position each frame to get scrolling effect
		Position = new Vector2(Position.X, Position.Y - (SCROLL_SPEED * (float)delta));
        if(Input.IsActionPressed("dialogueNext".AsStringName()))
        {
            Position = new Vector2(Position.X, Position.Y - (SCROLL_SPEED * (float)delta));
        } 
        if(Position.Y < -1000)
        {
            GetTree().Quit();
        }
	}
}
