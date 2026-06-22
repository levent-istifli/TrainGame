using Godot;
using GodotStringIntercept;
using System;

public partial class PlayerNew : CharacterBody2D
{
	Sprite2D sprite;
	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
	}

	[Export]
	public float speed = 50;
	Vector2 direction = Vector2.Zero;

	public override void _PhysicsProcess(double delta)
	{
		if (direction.X > 0)
		{
			sprite.FlipH = true;
		}
		else if (direction.X < 0) {
			sprite.FlipH = false;
		}
			MoveAndSlide();
		playerMovement();
	}

	public void playerMovement() {
		direction = Input.GetVector("ui_left".AsStringName(), "ui_right".AsStringName(), "ui_up".AsStringName(), "ui_down".AsStringName());
		Velocity = direction * speed;
	}
}
