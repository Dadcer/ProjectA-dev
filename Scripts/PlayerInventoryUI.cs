using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerInventoryUI : Control
{
	[Export]
	public Inventory inventory;
	public bool isInventoryOpen=false;
	public List<TextureRect>icons;
	public void openInventory() {
			changeInventoryVisible();
	}
	public void changeInventoryVisible() {
		isInventoryOpen=!isInventoryOpen;
	}
	public void setItemsTexture(Texture2D texture) {
		   foreach (var icon in icons) {
			if(icon.Texture is null) {
				icon.Texture = texture;
			}
		   }
	}
	public override void _Ready()
	{
		this.Visible = false;
		icons.Add(GetNode<TextureRect>("InventoryUI/InventoryUI/GridContainer/TextureRect"));
	
		icons.Add(GetNode<TextureRect>("InventoryUI/InventoryUI/GridContainer/TextureRect2"));

		icons.Add(GetNode<TextureRect>("InventoryUI/InventoryUI/GridContainer/TextureRect3"));

		icons.Add(GetNode<TextureRect>("InventoryUI/InventoryUI/GridContainer/TextureRect4"));

		icons.Add(GetNode<TextureRect>("InventoryUI/InventoryUI/GridContainer/TextureRect5"));

		icons.Add(GetNode<TextureRect>("InventoryUI/InventoryUI/GridContainer/TextureRect6"));

		icons.Add(GetNode<TextureRect>("InventoryUI/InventoryUI/GridContainer/TextureRect7"));

		icons.Add(GetNode<TextureRect>("InventoryUI/InventoryUI/GridContainer/TextureRect8"));

		icons.Add(GetNode<TextureRect>("InventoryUI/InventoryUI/GridContainer/TextureRect9"));

		
	}
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("inventoryOpen")) {
			openInventory();
		}
		this.Visible = isInventoryOpen;
	}
}
