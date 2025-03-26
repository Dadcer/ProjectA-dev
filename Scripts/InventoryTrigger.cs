using Godot;
using System;

public partial class InventoryTrigger : Area2D
{
	[Export]
	public Inventory inventory;
	[Export]
	public PlayerInventoryUI inventoryUI;
	public void _on_inventory_trigger_area_entered(Area2D area) {
		if(area is ItemScene itemScene) {
			inventory.addInventory(itemScene.item);
			itemScene.deleteItemByTake();
			inventoryUI.setItemsTexture(itemScene.item.texture);
		}
	}
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
		
	}
}
