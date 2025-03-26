using Godot;
using System;

public partial class ItemWeapon : Item
{
    
    [Export]
    public Texture2D weaponBulletTexture;
    [Export]
    public float weapDamage;
    [Export]
    public float weapActionPointsUse;
    [Export]
    public float weapAccuracy;

}
