using Godot;
using System;

public partial class PlayerNew : CharacterBody2D
{

	public override void _Ready()
	{
		this.Position = new Vector2(64, 64);
	}

	[Export]
	public float maxVelocity = 256;

	[Export]
	public float acceleration = 512;

	[Export]
	public float friction = 800;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = new Vector2(0, 0);
		Vector2 acceleration_vector = new Vector2(0, 0);

		if (Input.IsActionPressed("ui_right")) 
		{
			direction.X += 1;
		}
		if (Input.IsActionPressed("ui_left"))
		{
			direction.X -= 1;
		}
		if (Input.IsActionPressed("ui_down"))
		{
			direction.Y += 1;
		}
		if (Input.IsActionPressed("ui_up"))
		{
			direction.Y -= 1;
		}


		if (direction != Vector2.Zero) 
		{
			direction = direction.Normalized(); 
			acceleration_vector = direction * acceleration; 
		}
		else 
		{
			acceleration_vector = Vector2.Zero; 
		}

		Velocity += acceleration_vector * (float)delta;
		if (Velocity.Length() > maxVelocity) 
		{
			Velocity = Velocity.Normalized() * maxVelocity; 
		}

		MoveAndSlide();
		//// Add the gravity.
		//if (!IsOnFloor())
		//{
		//	velocity += GetGravity() * (float)delta;
		//}

		//// Handle Jump.
		//if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		//{
		//	velocity.Y = JumpVelocity;
		//}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		//Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		//if (direction != Vector2.Zero)
		//{
		//	velocity.X = direction.X * Speed;
		//}
		//else
		//{
		//	velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		//}

		//Velocity = velocity;
	}
}
