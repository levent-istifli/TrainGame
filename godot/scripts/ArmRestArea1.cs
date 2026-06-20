using Godot;
using System;

public partial class ArmRestArea1 : Area2D
{
	[Export] public Polygon2D ARPoly1;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (ARPoly1 == null) {
			GD.PrintErr($"ARPoly1 node null ${Name}");
			return;
		}
		
		ARPoly1.Modulate = new Color("#0000");
		
		MouseEntered += ChangeColor;
		MouseExited += RevertColor;
	}
	
	public void ChangeColor() {
		ARPoly1.Modulate = new Color("#ff000030");
	}
	
	public void RevertColor() {
		ARPoly1.Modulate = new Color("#0000");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
