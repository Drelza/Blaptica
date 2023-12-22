using Godot;
using System;

public partial class BlueEnemy : BaseEnemy
{
    public override void _Ready()
    {
        base._Ready();
        GD.Print("Spawn Blue Enemy");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }
}
