using Godot;
using System;

[GlobalClass]
public partial class Ship : Node2D
{
    [Export]
	public Area2D CollisionArea;
}
