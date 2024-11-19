using Godot;
using System;
using System.Numerics;
using System.Runtime.Serialization;
public partial class rat : CharacterBody2D
{	[Export]
	public float ratHp=1;
	[Export]
	public float ratSpeed=200;
	public int actionPointsRat=5;
	public bool ratMove=false;
	public Godot.Vector2 _target;
	public Godot.Vector2 direction;
	public void getPlayerPosition() {
		_target=player.Instance.Position-Position;
		direction=_target.Normalized();
		Velocity=direction*ratSpeed;
	}
	public void _on_button_pressed() {
		ratHp-=player.Instance.weapon.damage;
		player.Instance.actionPointsPlayer-=10;
	}
	public void checkDead() {
		if(ratHp<=0) {
			QueueFree();
			player.Instance.batleMode=false;
		}
	}
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{   
		checkDead();
		getPlayerPosition();
		MoveAndSlide();
	}
}
