using Godot;
using System;

public partial class Wave : Node2D
{
    public override void _Ready()
    {
        base._Ready();
        GD.Print("Wave Ready");
    }
}
