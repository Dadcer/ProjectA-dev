using Godot;
using System;
using System.Collections.Generic;

public partial class Inventory : Node2D
{
	public List<Item> inventoryCells = new List<Item>();

	public event Action OnUpdate;

	public void addItem(Item item)
	{
		inventoryCells.Add(item);
		OnUpdate?.Invoke();
	}
	public override void _Process(double delta)
	{
	}
}