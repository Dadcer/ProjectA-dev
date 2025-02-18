using Godot;
using System;
using System.Collections.Generic;

public partial class FightTrigger : Area2D
{
    public bool startBattle = false;
    public List<Area2D> members = new List<Area2D>();
    public void _on_area_entered(Area2D fighter)
    {
        if (fighter is IFighter)
        {
            members.Add(fighter);
            startBattle = true;
        }
    }
    public override void _Ready()
    {

    }
    public override void _Process(double delta)
    {

    }

}
