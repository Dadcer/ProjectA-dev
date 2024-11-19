using Godot;
using System;
using System.Text.Unicode;
using System.Timers;

public partial class player : CharacterBody2D
{
	public Bullet bulllet_;
	public Marker marker;
	[Export]
	public WeaponRes weapon;
	[Export]
	public Inventory inventory;
	public static player Instance;
	public enemy enemy;
	public Vector2 _target;
	public Vector2 targetPosition;
	[Export]
	public int maxHpPlayer=10;
	[Export]
	public int hpPlayer=10;
	public float speedPlayer=200;
	public int actionPointsPlayer=100;
	private float RegenerationTimer=0.0f;
	[Export]
	public float RegenerationSpeed = 1.0f;
	public bool move=true;
	public bool batleMode=false;
	public float damage=1;
	public int numberOfEnemy=0;
	
	public  player() {
		inventory=new Inventory();
		marker=new Marker();
	}
	public void hpCheckPLayer() {
		if(hpPlayer<=0) {
			QueueFree();
		}
	}
	public void moveDetect() 
	{
		if(Input.IsActionJustPressed("mouseRight")&&batleMode is false) {

		_target=GetGlobalMousePosition();
		}
		Velocity=Position.DirectionTo(_target)*speedPlayer;
	}
	public void battleStart() {
		if(actionPointsPlayer>0&&batleMode is true) {
			if(Input.IsActionJustPressed("mouseRight")) {
				_target=GetGlobalMousePosition();
				if(Position.DistanceTo(_target)<=100) {
					actionPointsPlayer=actionPointsPlayer-1;
				}
				if(Position.DistanceTo(_target)>150) {
					actionPointsPlayer=actionPointsPlayer-2;
				}
				if(Position.DistanceTo(_target)>200) {
					actionPointsPlayer=actionPointsPlayer-3;
				}
				if(Position.DistanceTo(_target)>250) {
					actionPointsPlayer=actionPointsPlayer-4;
				}
				if(Position.DistanceTo(_target)>300) {
					actionPointsPlayer=actionPointsPlayer-5;
				}
			}
		}
	}
	public void setProgressBar() {
		var progressBar=GetNode<ProgressBar>("ProgressBar");
		progressBar.Value=actionPointsPlayer;
	}
	public void setBattleMode() {
		batleMode=true;
	}
	public void setBattleModeFalse() {
		batleMode=false;
	}
	private void _on_enemy_check_area_body_entered(Node2D body)
{
	if(body is rat) {
	numberOfEnemy+=1;
	}
}
	private void _on_enemy_check_area_body_exited(Node2D body)
{
	if(body is rat) {
		numberOfEnemy-=1;
	}
}
public void battleMode() {
	if(numberOfEnemy>=1) {
		setBattleMode();
	}
	if(numberOfEnemy<=0) {
		setBattleModeFalse();
	}
}
	public override void _Ready()
	{
		Instance=this;
		
	}
	public override void _Process(double delta)
	
	
	{
		setProgressBar();
		battleStart();
		battleMode();
		moveDetect();
		hpCheckPLayer();
		MoveAndSlide();
		if(actionPointsPlayer<100){
		 if(RegenerationTimer < 0.0f){
			actionPointsPlayer +=5;
			RegenerationTimer = 1.0f;
		}
		else{
			RegenerationTimer -= (float)delta * RegenerationSpeed;
		}
		}
		GD.Print(actionPointsPlayer);
	}
}
