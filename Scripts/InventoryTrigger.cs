using Godot;
using System;

public partial class InventoryTrigger : Area2D
{
	[Export]
	public Inventory inventory;
	[Export]
	public PlayerInventoryUI inventoryUI;

	public void OnAreaEntered(Area2D area)
	{
		if (area is ItemScene itemScene)
		{
			inventory.addItem(itemScene.item);
			itemScene.deleteItemByTake();
		}
	}
	public override void _Ready()
	{
		AreaEntered += OnAreaEntered;
	}
	public override void _Process(double delta)
	{

	}
}
