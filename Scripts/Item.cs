using Godot;
using System;

public partial class Item : Area2D, ICursorInteractable
{
    public void Interact(Corsour cursor)
    {
        GD.Print("interact!!!!");
    }

}
