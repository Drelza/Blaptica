using System;
using Godot;

public partial class Player : Node2D
{
    [Export]
    public float Padding = 35;

    [Export]
    public PackedScene LaserScene;

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        followMouse();
        handleInput();
    }

    private void handleInput()
    {
        if (Input.IsActionJustPressed("primary"))
        {
            var laser = LaserScene.Instantiate<Laser>();
            laser.Position = Position;
            AddSibling(laser);
        }
    }

    private void followMouse()
    {
        var newPosition = Position;
        newPosition.X = Mathf.Clamp(GetGlobalMousePosition().X,0 + Padding,540 - Padding);
        Position = newPosition;
    }
}
