using Godot;
using System;
interface ILivingState{
	float takeDamage();
}
public partial class LivingState : Node2D
{	
	public float playerHP=100;
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
	}
}
