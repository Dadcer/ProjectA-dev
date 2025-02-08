using Godot;
using System;

public partial class EnemyFighter : Node2D, IFighter
{
	public bool isBattle = true;
	public bool isTurn = true;
	[Export]
	public Enemy enemy;
	public double actionPoints = 50;
	public void _on_player_check_body_entered(Node2D body)
	{
		if (body is Player)
		{
			enemy.player = body;
		}
	}
	public void StartBattle()
	{
		isBattle = true;
		isTurn = true;
	}
	public void TakeTurn()
	{

	}
	public void EndTurn()
	{
		if (actionPoints <= 0)
		{
			isTurn = false;
		}
	}
	public void FightEnd()
	{

	}
	public override void _Ready()
	{
		enemy.actionPoints = actionPoints;
	}
	public override void _Process(double delta)
	{
		enemy.isBattle = isBattle;
		enemy.isTurn = isTurn;
		actionPoints = enemy.actionPoints;
		EndTurn();

	}
}
