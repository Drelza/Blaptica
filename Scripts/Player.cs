using System;
using Godot;

public partial class Player : Node2D
{
    [Export]
    public float Padding = 35;

    [Export]
    public PackedScene LaserScene;

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

        HandleInput();
    }

    private void OnAreaEntered(Area2D area)
    {
        GameEvents.PlayerHit?.Invoke();
    }

    private void OnGameOver()
    {
        QueueFree();
    }

    private void HandleInput()
    {
        FollowMouse();

        if (Input.IsActionJustPressed("primary"))
        {
            FireLaser();
        }
    }

    private void FireLaser()
    {
        var laser = LaserScene.Instantiate<Laser>();
        laser.Position = Position;
        AddSibling(laser);
    }

    private void FollowMouse()
    {
        var newPosition = Position;
        newPosition.X = Mathf.Clamp(GetGlobalMousePosition().X, 0 + Padding, 540 - Padding);
        Position = newPosition;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        GameEvents.GameOver -= OnGameOver;
    }
}
