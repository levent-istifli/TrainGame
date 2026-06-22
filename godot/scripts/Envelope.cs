using Godot;
using System;

public partial class Envelope : Area2D
{
	[Export] public Polygon2D Letter;
	[Export] public Label LetterLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (Letter == null) {
			GD.PrintErr($"Letter node null ${Name}");
			return;
		}
		
		Letter.Modulate = new Color("#0000");
		LetterLabel.Modulate = new Color("#000000");
		
		MouseEntered += ChangeColor;
		MouseExited += RevertColor;
	}
	
	public void ChangeColor() {
		Letter.Modulate = new Color("#ff000030");
		LetterLabel.Modulate = new Color("#ff0000");
	}
	
	public void RevertColor() {
		Letter.Modulate = new Color("#0000");
		LetterLabel.Modulate = new Color("#000000");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
