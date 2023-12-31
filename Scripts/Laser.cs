using Godot;
using System;

[GlobalClass]
public partial class Laser : Node2D
{
    [Export]
    public float Velocity = 1000;

    [Export]
    public Area2D CollisionArea;

    public override void _Ready()
    {
        base._Ready();

        CollisionArea.AreaEntered += OnAreaEntered;
        GameEvents.GameOver += OnGameOver;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        Vector2 newPosition = Position;
        newPosition.Y -= (float)(Velocity * delta);
        Position = newPosition;
    }

    private void OnAreaEntered(Area2D area)
    {
        QueueFree();
    }

    private void OnGameOver()
    {
        QueueFree();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        GameEvents.GameOver -= OnGameOver;
    }
}
