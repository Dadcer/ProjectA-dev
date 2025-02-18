using Godot;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public partial class PlayerSystem : CharacterBody2D
{

	[Export]
	public int Speed = 400;
	[Export]
	public Sprite2D movementPoint;
	[Export]
	public PlayerFighter playerFighter;
	private Vector2 targetPoint;
	public bool isMoving = false;
	public float distanceTraveled;
	public PlayerSystem()
	{

	}

	public void ProcessMovement()
	{
		if (playerFighter.isBattle is false)
		{
			movementPoint.Visible = false;

			if (!isMoving) return;
			movementPoint.Visible = true;
			movementPoint.GlobalPosition = targetPoint;

			Velocity = Position.DirectionTo(targetPoint) * Speed;
			if (GlobalPosition.DistanceTo(targetPoint) <= 40.0f)
			{
				isMoving = false;
			}
			MoveAndSlide();
		}
	}
	public void ProcessMovementInBattle(float delta)
	{
		if (playerFighter.isBattle is true && playerFighter.isTurn is true)
		{
			movementPoint.Visible = false;

			if (!isMoving) return;
			movementPoint.Visible = true;
			movementPoint.GlobalPosition = targetPoint;

			Velocity = Position.DirectionTo(targetPoint) * Speed;
			if (GlobalPosition.DistanceTo(targetPoint) <= 40.0f)
			{
				isMoving = false;
			}
			MoveAndSlide();
			playerFighter.moving(delta);
		}

	}
	public void MoveTo(Vector2 toPoint)
	{
		targetPoint = toPoint;
		isMoving = true;
	}

	public override void _PhysicsProcess(double delta)
	{
		ProcessMovement();
		ProcessMovementInBattle((float)delta);
	}
}
