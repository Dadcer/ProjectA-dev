using Godot;
using System;
using System.Collections.Generic;

public partial class FightTrigger : Area2D
{
    public override void _Ready()
    {
        AreaEntered += OnAreaEntered;
    }
    public List<Node2D> members = new List<Node2D>();
    public void OnAreaEntered(Node2D node)
    {
        if (node is EnemyFighter)
        {
            members.Add(node);
        }
    }
    public override void _Process(double delta)
    {
        GD.Print(members[0]);
    }

}
