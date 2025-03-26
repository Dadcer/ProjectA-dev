using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerInventoryUI : Control
{
	[Export]
	public Inventory inventory;
	public bool isInventoryOpen = false;
	public List<TextureRect> icons = new List<TextureRect>();
	public void openInventory()
	{
		changeInventoryVisible();
	}
	public void changeInventoryVisible()
	{
		isInventoryOpen = !isInventoryOpen;
	}
	public void setItemsTexture(Texture2D texture)
	{
		foreach (var icon in icons)
		{
			if (icon.Texture is null)
			{
				icon.Texture = texture;
			}
		}
	}

	[Export]
	public Node CellsContainer;
	[Export]
	public PackedScene CellScene;

	protected void RenderCells()
	{
		ClearCells();
		FillCells();
	}

	protected void ClearCells()
	{
		foreach (var cellNode in CellsContainer.GetChildren())
		{
			cellNode.QueueFree();
		}
	}
	protected void FillCells()
	{
		foreach (var cell in inventory.inventoryCells)
		{
			var newCell = CellScene.Instantiate<InventoryCellUI>();
			newCell.inventoryCell = cell;
			CellsContainer.AddChild(newCell);
		}
	}

	public override void _Ready()
	{
		this.Visible = false;
		inventory.OnUpdate += RenderCells;
	}
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("inventoryOpen"))
		{
			openInventory();
		}
		this.Visible = isInventoryOpen;
	}
}
