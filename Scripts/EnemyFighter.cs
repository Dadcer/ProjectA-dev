using Godot;
using System;

public partial class EnemyFighter : Area2D, IFighter
{
	public bool isBattle;
	public bool isTurn;
	public Node2D player;
	public float actionPoints = 50;
	public float actionPointUseSpeed = 50.0f;

	public void _on_body_entered(Node2D body)
	{
		if (body is PlayerSystem)
		{
			player = body;
		}
	}
	public void StartBattle()
	{
		isBattle = true;
	}
	public void TakeTurn()
	{
		isTurn = true;
	}
	public void TurnBehaivor()
	{

	}
	public void moving(float delta)
	{
		actionPoints = actionPoints - (delta * actionPointUseSpeed);
	}
	public bool EndTurn()
	{
		if (actionPoints <= 0)
		{
			isTurn = false;
			return true;
		}
		return false;
	}
	public void RefreshActionPoints()
	{
		actionPoints = 100.0f;
	}

	public void FightEnd()
	{

	}
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
		EndTurn();
	}
}
