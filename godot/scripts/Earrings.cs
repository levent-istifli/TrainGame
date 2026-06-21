using Godot;
using System;

public partial class Earrings : Area2D
{
	[Export] public Polygon2D EarringPoly1;
	[Export] public Polygon2D EarringPoly2;
	[Export] public Label EarringLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (EarringPoly1 == null || EarringPoly2 == null) {
			GD.PrintErr($"EarringPoly node null ${Name}");
			return;
		}
		
		EarringPoly1.Modulate = new Color("#0000");
		EarringPoly2.Modulate = new Color("#0000");
		EarringLabel.Modulate = new Color("#000000");
		
		MouseEntered += ChangeColor;
		MouseExited += RevertColor;
	}
	
	public void ChangeColor() {
		EarringPoly1.Modulate = new Color("#ff000030");
		EarringPoly2.Modulate = new Color("#ff000030");
		EarringLabel.Modulate = new Color("#ff0000");
	}
	
	public void RevertColor() {
		EarringPoly1.Modulate = new Color("#0000");
		EarringPoly2.Modulate = new Color("#0000");
		EarringLabel.Modulate = new Color("#000000");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
