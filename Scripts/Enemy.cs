using Godot;
using System;

public partial class Enemy : Node2D
{
	[Export]
	public Area2D CollisionArea;

	[Export]
	public float Speed = 200;

	public int ScoreValue = 1;

	public override void _Ready()
	{
		base._Ready();
		CollisionArea.AreaEntered += onBodyEntered;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);

		var newPosition = Position;
		newPosition.Y += Speed * (float)delta;
		Position = newPosition;
	}

	private void onBodyEntered(Node2D body)
	{
		QueueFree();

		if (GameEvents.EnemyDestroyed != null)
			GameEvents.EnemyDestroyed(this);
	}
}
