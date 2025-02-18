using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


public partial class FightManager : Node2D
{
	[Export]
	public FightTrigger fightTrigger;
	public List<Area2D> fighters = new List<Area2D>();
	public bool startBattle = false;
	public int stepCounter = 0;

	public void setBattle()
	{
		foreach (IFighter fighter in fighters)
		{
			fighter.StartBattle();

		}
	}
	public void setFighterThatHasStep(Area2D member)
	{
		if (member is IFighter fighter)
		{
			fighter.TakeTurn();
			if (fighter.EndTurn())
			{
				stepCounter++;
			}
		}
	}
	public void refreshStepCounter()
	{
		stepCounter = 0;
	}
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
		fighters = fightTrigger.members;
		startBattle = fightTrigger.startBattle;
		if (startBattle)
		{
			setBattle();
			setFighterThatHasStep(fighters[stepCounter]);
		}
		if (stepCounter >= fighters.Count)
		{
			refreshStepCounter();
			foreach (IFighter fighter in fighters)
			{
				fighter.RefreshActionPoints();
			}
		}
	}
}
