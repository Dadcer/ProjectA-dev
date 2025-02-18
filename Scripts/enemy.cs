using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Enemy : CharacterBody2D
{
	[Export]
	public EnemyFighter enemyFighter;
	public Node2D player;
	public Vector2 target;
	public float speed = 50;
	public void Move(float delta)
	{
		if (enemyFighter.isBattle && enemyFighter.isTurn)
		{
			target = player.Position;
			Velocity = Position.DirectionTo(target) * speed;
			MoveAndSlide();
			enemyFighter.moving(delta);
		}
	}
	public override void _Process(double delta)
	{
		player = enemyFighter.player;
		Move((float)delta);
	}
}