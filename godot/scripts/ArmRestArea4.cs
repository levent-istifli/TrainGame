using Godot;
using System;

public partial class ArmRestArea4 : Area2D
{
	[Export] public Polygon2D ARPoly4;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (ARPoly4 == null) {
			GD.PrintErr($"ARPoly4 node null ${Name}");
			return;
		}
		
		ARPoly4.Modulate = new Color("#0000");
		
		MouseEntered += ChangeColor;
		MouseExited += RevertColor;
	}
	
	public void ChangeColor() {
		ARPoly4.Modulate = new Color("#ff000030");
	}
	
	public void RevertColor() {
		ARPoly4.Modulate = new Color("#0000");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
