using Godot;
using System;

public partial class RedEnemy : EnemyShip
{
    public override void _Ready()
    {
        base._Ready();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        Move(delta, Vector2.Down);
    }
}
