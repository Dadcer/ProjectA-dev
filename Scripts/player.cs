using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Player : CharacterBody2D
{
	[Export]
	public int Speed = 400;
	[Export]
	public Sprite2D movementPoint;

	private Vector2 targetPoint;
	public bool isMoving = false;
	public Player() {
		
	}

	public void ProcessMovement() {
		movementPoint.Visible = false;
		
		if(!isMoving) return;
		movementPoint.Visible = true;
		movementPoint.GlobalPosition = targetPoint;

		Velocity=Position.DirectionTo(targetPoint)*Speed;
		if(GlobalPosition.DistanceTo(targetPoint) <= 40.0f){
			isMoving = false;
		}
		

		MoveAndSlide();
	}
	public void MoveTo(Vector2 toPoint){
		targetPoint = toPoint;
		isMoving = true;
	}

	public override void _PhysicsProcess(double delta)
	{
		ProcessMovement();
	}
}
