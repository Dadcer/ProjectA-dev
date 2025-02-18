using Godot;
using System;

public partial class PlayerFighter : Area2D, IFighter
{

	public bool isBattle;
	public bool isTurn;
	[Export]
	public PlayerSystem player;
	public float actionPointUseSpeed = 20.0f;
	public float actionPoints = 100;
	public float distanceTraveled;
	public void moving(float delta)
	{
		actionPoints = actionPoints - (delta * actionPointUseSpeed);
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
		if (actionPoints > 0.0f)
		{
			actionPoints -= actionPointUseSpeed * (float)delta;
		}
		EndTurn();
	}
}
