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

        CollisionArea.AreaEntered += onAreaEntered;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        handleInput();
    }

    private void onAreaEntered(Area2D area)
    {
        var enemy = area.GetParent() as Enemy;
        QueueFree();

        if (GameEvents.PlayerDestroyed != null)
            GameEvents.PlayerDestroyed(enemy);
    }

    private void handleInput()
    {
        followMouse();

        if (Input.IsActionJustPressed("primary"))
        {
            fireLaser();
        }
    }

    private void fireLaser()
    {
        var laser = LaserScene.Instantiate<Laser>();
        laser.Position = Position;
        AddSibling(laser);
    }


    private void followMouse()
    {
        var newPosition = Position;
        newPosition.X = Mathf.Clamp(GetGlobalMousePosition().X, 0 + Padding, 540 - Padding);
        Position = newPosition;
    }
}
