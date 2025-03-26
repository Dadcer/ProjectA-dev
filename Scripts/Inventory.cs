using Godot;
using System;
using System.Collections.Generic;

public partial class Inventory : Node2D
{	public List<Item> inventoryCells=new List<Item>();
	public void addInventory(Item item) {
		inventoryCells.Add(item);
	}
	public override void _Process(double delta)
	{
	}
}