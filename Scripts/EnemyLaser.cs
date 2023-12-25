using Godot;
using System;

public partial class EnemyLaser : Laser
{
    public override void _Ready()
    {
        base._Ready();

        Velocity *= -1;
    }
}
