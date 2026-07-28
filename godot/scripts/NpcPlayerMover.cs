using Godot;
using System;
using System.Collections.Generic;

public partial class NpcPlayerMover : CharacterBody2D
{
    [Export] public Area2D interactor;
    [Export] public Node2D targetSeat;
    [Export] public double aisleYPosition;
    [Export] public string name;

    const float WALK_SPEED = 300.0f;

    List<Vector2> movementTargets = new List<Vector2>();
    bool isMoving = false;
    bool isExiting = false;
    Vector2 originalPosition;

    public override void _Ready()
    {
        base._Ready();
        originalPosition = GlobalPosition;
        if(interactor != null)
        {
            Visible = false;
            interactor.ProcessMode = ProcessModeEnum.Disabled;
        }
    }


	public override void _PhysicsProcess(double delta)
	{
        if(isMoving)
        {
            if(MoveToTarget())
            {
                if(isExiting)
                {
                    QueueFree();
                }
                else
                {
                    isMoving = false;
                    interactor.ProcessMode = ProcessModeEnum.Inherit;   
                }
            }
        }
	}

    public void BoardTrain()
    {
        isMoving = true;
        Visible = true;
        movementTargets.Add(targetSeat.GlobalPosition);
        movementTargets.Add(new Vector2(targetSeat.GlobalPosition.X, (float)aisleYPosition));
        movementTargets.Add(new Vector2(Position.X, (float)aisleYPosition));
        FaceTowards(movementTargets[movementTargets.Count - 1]);
    }

    public void ExitTrain()
    {
        isMoving = true;
        isExiting = true;
        movementTargets.Add(originalPosition);
        movementTargets.Add(new Vector2(originalPosition.X, (float)aisleYPosition));
        movementTargets.Add(new Vector2(GlobalPosition.X, (float)aisleYPosition));
        FaceTowards(movementTargets[2]);
    }

    public void FaceTowards(Vector2 target)
    {
        if(GlobalPosition.X == target.X)
        {
            if(GlobalPosition.Y < target.Y)
            {
                Velocity = new Vector2(0, WALK_SPEED);
            }
            else
            {
                Velocity = new Vector2(0, -WALK_SPEED);
            }
        }
        else
        {
            if(GlobalPosition.X < target.X)
            {
                Velocity = new Vector2(WALK_SPEED, 0);
            }
            else
            {
                Velocity = new Vector2(-WALK_SPEED, 0);
            }
        }
    }

    public bool MoveToTarget()
    {
        var oldPosition = GlobalPosition;
        MoveAndSlide();
        var newPosition = GlobalPosition;
        float target, pre, post;
        if(oldPosition.X == newPosition.X)
        {
            target = movementTargets[movementTargets.Count - 1].Y;
            pre = oldPosition.Y;
            post = newPosition.Y;
        }
        else
        {
            target = movementTargets[movementTargets.Count - 1].X;
            pre = oldPosition.X;
            post = newPosition.X;
        }
        if(Math.Sign(target - pre) != Math.Sign(target - post))
        {
            GlobalPosition = movementTargets[movementTargets.Count - 1];
            movementTargets.RemoveAt(movementTargets.Count - 1);
            if(movementTargets.Count == 0)
            {
                return true;
            }
            else
            {
                FaceTowards(movementTargets[movementTargets.Count - 1]);
                return false;
            }
        }
        return false;
    }
}
