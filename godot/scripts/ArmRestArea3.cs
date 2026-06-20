using Godot;
using System;

public partial class ArmRestArea3 : Area2D
{
	[Export] public Polygon2D ARPoly3;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (ARPoly3 == null) {
			GD.PrintErr($"ARPoly3 node null ${Name}");
			return;
		}
		
		ARPoly3.Modulate = new Color("#0000");
		
		MouseEntered += ChangeColor;
		MouseExited += RevertColor;
	}
	
	public void ChangeColor() {
		ARPoly3.Modulate = new Color("#ff000030");
	}
	
	public void RevertColor() {
		ARPoly3.Modulate = new Color("#0000");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
