using Godot;
using System;

public partial class WeaponRes : Resource
{
 [Export]
 public string name;
 [Export]
 public float damage;
 [Export]
 public float speed;
 [Export]
 public float magazine;
 [Export]
 public float ammoConsume;
 [Export]
 public float rechargeTime;
 [Export]
 public Texture2D texture;
}
