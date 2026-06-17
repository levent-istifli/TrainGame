using Godot;
using System;

public partial class Polygon2d3 : Polygon2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// prevent sprite from having polygon outline on initialization
		Modulate = new Color("#0000");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void ChangeColor() {
		Modulate = new Color("#00FF0030");
	}
	
	public void RevertColor() {
		Modulate = new Color("#0000");
	}
}
