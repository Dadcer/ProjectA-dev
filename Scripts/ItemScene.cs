using Godot;
using System;

public partial class ItemScene : Area2D
{
	[Export]
	public Item item;
	public void setItemInformation() {
		var texture =  GetNode<Sprite2D>("Sprite2D");
		texture.Texture = item.texture;
		var name=GetNode<RichTextLabel>("RichTextLabel");
		name.Text = item.name;
		
	}
	public void deleteItemByTake() {
		this.QueueFree();
	}
	public override void _Ready()
	{
	setItemInformation();	
	}
	public override void _Process(double delta)
	{
		
	}
}
