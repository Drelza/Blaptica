using Godot;
using System;

/// <summary>
/// Root player node
/// </summary>
public partial class Player : Node2D
{
    /// <summary>
    /// The ammount of padding on the left and right of the screen for player movement
    /// </summary>
    [Export]
    public float Padding = 35;

    public override void _Process(double delta)
    {
        base._Process(delta);

        FollowMouse();
    }

    /// <summary>
    /// Moves the player node to follow the mouse x position clamped withing the screen
    /// </summary>
    private void FollowMouse()
    {
        var newPosition = Position;
        newPosition.X = Mathf.Clamp(GetGlobalMousePosition().X,0 + Padding,540 - Padding);
        Position = newPosition;
    }
}
