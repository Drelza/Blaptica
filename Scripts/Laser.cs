using Godot;
using System;

public partial class Laser : Node2D
{
    [Export]
    public float Velocity = 1000;

    public override void _Process(double delta)
    {
        base._Process(delta);
        
        Vector2 newPosition = Position;
        newPosition.Y -= (float)(Velocity * delta);
        Position = newPosition;
    }
}
