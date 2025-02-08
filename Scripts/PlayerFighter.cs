using Godot;
using System;

public partial class PlayerFighter : Area2D, IFighter
{

	public bool isBattle = true;
	public bool isTurn = true;
	[Export]
	public Player player;
	public float actionPointUseSpeed = 10.0f;
	public float actionPoints = 100.0f;
	public float distanceTraveled;
	public void StartBattle()
	{
		isTurn = true;
		isBattle = true;
	}
	public void EndTurn()
	{
		isTurn = false;
	}
	public void FightEnd()
	{

	}
	public void TakeTurn()
	{
		actionPoints = 100;
	}
	public override void _Ready()
	{

	}
	public override void _Process(double delta)
	{
		if (actionPoints > 0.0f)
		{
			actionPoints -= actionPointUseSpeed * (float)delta;
		}
		if (actionPoints <= 0.0f)
		{
			EndTurn();
		}
	}
}
