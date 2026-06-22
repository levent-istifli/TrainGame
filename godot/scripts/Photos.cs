using Godot;
using System;

public partial class Photos : Area2D
{
	[Export] public Polygon2D Photo;
	[Export] public Label PhotoLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (Photo == null) {
			GD.PrintErr($"Photo node null ${Name}");
			return;
		}
		
		Photo.Modulate = new Color("#0000");
		PhotoLabel.Modulate = new Color("#000000");
		
		MouseEntered += ChangeColor;
		MouseExited += RevertColor;
	}
	
	public void ChangeColor() {
		Photo.Modulate = new Color("#ff000030");
		PhotoLabel.Modulate = new Color("#ff0000");
	}
	
	public void RevertColor() {
		Photo.Modulate = new Color("#0000");
		PhotoLabel.Modulate = new Color("#000000");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
