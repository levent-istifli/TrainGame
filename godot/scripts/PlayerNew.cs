using Godot;
using GodotStringIntercept;
using System;

public partial class PlayerNew : CharacterBody2D
{
	[Export] Sprite2D sprite;

	[Export]
	public float speed = 50;
	Vector2 direction = Vector2.Zero;

	[Export] AudioStreamPlayer footsteps;
    [Export] public Area2D interactionDetector;

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
        if(Input.IsActionJustPressed("ui_accept".AsStringName()))
        {
            if(interactionDetector.HasOverlappingAreas())
            {
                var interact = (NPCPlayer)interactionDetector.GetOverlappingAreas()[0];
                if(interact.ProcessMode != ProcessModeEnum.Disabled)
                {
                    interact.doEvent();
                }
            }
        }
		playerMovement();
	}

	public void playerMovement() {
		direction = Input.GetVector("ui_left".AsStringName(), "ui_right".AsStringName(), "ui_up".AsStringName(), "ui_down".AsStringName());
		Velocity = direction * speed;

		bool isMoving = false;
		if (direction != Vector2.Zero) { 
			isMoving = true;
		}

		if (isMoving && !footsteps.Playing)
		{
			footsteps.Play();
		}
		else if (!isMoving && footsteps.Playing) { 
			footsteps.Stop();
		}
	}
}
