using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Enemy : CharacterBody2D
{
	public Vector2 target;
	public float speed = 100;
	public bool isTurn;
	public bool isBattle;
	public Node2D player;
	public double actionPoints;
	public void Move()
	{
		if (isBattle is true && isTurn is true)
		{
			target = player.Position;
			Velocity = GlobalPosition.DirectionTo(target) * speed;
			actionPoints = actionPoints - 0.5;
			MoveAndSlide();
		}
	}
	public override void _Process(double delta)
	{
		Move();
	}
}