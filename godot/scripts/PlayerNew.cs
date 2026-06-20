using Godot;
using GodotStringIntercept;
using System;

public partial class PlayerNew : CharacterBody2D
{

	public override void _Ready()
	{
		//NavigationManager.Instance.TriggerPlayerSpawn += OnTriggerPlayerSpawnSignal;
	}

	[Export]
	public float speed = 50;
	Vector2 direction = Vector2.Zero;

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
		playerMovement();
	}

	public void playerMovement() {
		direction = Input.GetVector("ui_left".AsStringName(), "ui_right".AsStringName(), "ui_up".AsStringName(), "ui_down".AsStringName());
		Velocity = direction * speed;
	}
}
