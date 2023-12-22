using Godot;
using System;

public partial class RedEnemy : BaseEnemy
{
    public override void _Ready()
    {
        base._Ready();
        GD.Print("Spawn Red Enemy");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }
}
