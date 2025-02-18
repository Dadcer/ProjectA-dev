using Godot;
using System;
using System.Collections.Specialized;

public partial class Corsour : Node2D
{
	[Export]
	public PlayerSystem player;
	[Export]
	public Sprite2D sprite;
	[Export]
	public Area2D actionDetectorArea;
	[Export]
	public bool isActive = true;

	[Export]
	public Texture2D defaultIcon;
	[Export]
	public Texture2D interactableIcon;

	public void SetActive(bool state)
	{
		isActive = state;
		if (isActive)
		{
			this.Visible = true;
		}
		else
		{
			this.Visible = false;
		}
	}
	public void UpdatePosition()
	{
		GlobalPosition = GetGlobalMousePosition();
	}
	public void CheckControls()
	{
		if (Input.IsActionJustPressed("mouseRight"))
		{
			player.MoveTo(GlobalPosition);
		}
	}
	public void CheckInteractables()
	{
		sprite.Texture = defaultIcon;

		foreach (var area in actionDetectorArea.GetOverlappingAreas())
		{
			if (area is ICursorInteractable interactable)
			{
				sprite.Texture = interactableIcon;

				if (Input.IsActionJustPressed("mouseLeft"))
				{
					interactable.Interact(this);
				}
			}
		}
	}
	public override void _Ready()
	{
		SetActive(isActive);
	}
	public override void _Process(double delta)
	{
		UpdatePosition();
		if (isActive)
		{
			CheckControls();
			CheckInteractables();
		}
	}
}
