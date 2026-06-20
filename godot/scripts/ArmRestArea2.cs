using Godot;
using System;

public partial class ArmRestArea2 : Area2D
{
	[Export] public Polygon2D ARPoly2;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (ARPoly2 == null) {
			GD.PrintErr($"ARPoly2 node null ${Name}");
			return;
		}
		
		ARPoly2.Modulate = new Color("#0000");
		
		MouseEntered += ChangeColor;
		MouseExited += RevertColor;
	}
	
	public void ChangeColor() {
		ARPoly2.Modulate = new Color("#ff000030");
	}
	
	public void RevertColor() {
		ARPoly2.Modulate = new Color("#0000");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
