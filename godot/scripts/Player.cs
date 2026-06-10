using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public Sprite2D sprite;
	[Export]
	public CollisionShape2D collisionShape;
	public override void _Ready()
	{
		base._Ready();
	}

}
