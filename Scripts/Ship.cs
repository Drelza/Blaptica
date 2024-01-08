using Godot;
using System;

[GlobalClass]
public partial class Ship : Node2D
{
    [Export]
	public PackedScene LaserScene;

    [Export]
	public Area2D CollisionArea;

    protected void Shoot()
    {
		var laser = LaserScene.Instantiate<Laser>();
		laser.Position = Position;
        AddSibling(laser);
    }
}
