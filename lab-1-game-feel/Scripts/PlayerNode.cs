using Godot;
using System;
public partial class PlayerNode : CharacterBody3D
{

	int movementStyle = 0;

	Vector3 movementDirection = Vector3.Zero;
	float maxSpeed = 5f;
	float acceleration = 0f;
	float deceleration = 0f;

	Vector3 velocity;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public override void _PhysicsProcess(double delta)
    {
        Velocity = velocity;
    }

	void MoveForward()
	{
		velocity = Velocity;
		switch (movementStyle)
		{
			case 0:
				if (Input.IsActionPressed("Forward"))
				{
					
				}
				break;
				
				

		}
	}
}
