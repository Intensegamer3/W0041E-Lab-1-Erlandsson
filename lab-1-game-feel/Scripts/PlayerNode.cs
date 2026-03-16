using Godot;
using System;
public partial class PlayerNode : CharacterBody3D
{

	int movementMode = 1;

	public float movementOneSpeed = 5f;
	
	public float movementTwoAcceleration = 0.02f;
	public float movementTwoDeceleration = 3;
	public float movementTwoMaxSpeed = 5;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 inputDir = Input.GetVector("MoveWest", "MoveEast", "MoveNorth", "MoveSouth");

		Vector3 direction = new Vector3(inputDir.X, 0, inputDir.Y).Normalized();

		if(movementMode == 1) // Immediate acceleration, and immediate stop at deceleration
		{
			if (direction != Vector3.Zero)
			{
				Velocity = direction * movementOneSpeed;
			}
			else
			{
				Velocity = Vector3.Zero;
			}
		}
		else if (movementMode == 2) // Slow constant acceleration, fast constant deceleration
		{
			if (direction != Vector3.Zero)
			{
				Vector3 targetVelocity = direction * movementTwoMaxSpeed;
				Vector3 acceleration = targetVelocity * movementTwoAcceleration;

				Velocity += acceleration;
				
			}
			else
			{
				if(Velocity.Length() > 0.1f)
				{
					Vector3 deceleration = -Velocity.Normalized() * movementTwoDeceleration * (float)delta;
					Velocity = Velocity + deceleration;
				}
				else
				{
					Velocity = Vector3.Zero;
				}
			}

			
		}
		else if (movementMode == 3) // Ease acceleration, and constant deceleration
		{
			if (direction != Vector3.Zero)
			{
				Velocity = direction * movementOneSpeed;
			}
			else
			{
				Velocity = Vector3.Zero;
			}
		}
		else
		{
			return;
		}
		MoveAndSlide();
	}

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("SwitchMovementModeTo1"))
		{
			movementMode = 1;
		}
		
		if (@event.IsActionPressed("SwitchMovementModeTo2"))
		{
			movementMode = 2;
			Velocity.LimitLength(movementTwoMaxSpeed);
		}

		if (@event.IsActionPressed("SwitchMovementModeTo3"))
		{
			movementMode = 3;
		}
    }
}
