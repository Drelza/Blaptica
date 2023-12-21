using Godot;
using System;

public partial class EnemySpawner : Node2D
{
	[Export]
	public PackedScene Enemy;

	[Export]
	public float Padding = 10;

	private Timer timer;
	private bool enemiesCanSpawn;

	public override void _Ready()
	{
		enemiesCanSpawn = true;
		timer = GetNode("Timer") as Timer;

		timer.Timeout += onTimerTimeOut;
		Events.PlayerDestroyed += onPlayerDestroyed;
	}

	private void onPlayerDestroyed(Enemy killer)
	{
		enemiesCanSpawn = false;
	}

	private void onTimerTimeOut()
	{
		if (enemiesCanSpawn)
		{
			Enemy newEnemy = Enemy.Instantiate() as Enemy;
			float xPos = (float)GD.RandRange(0 + Padding, 540 - Padding);
			newEnemy.Position = new Vector2(xPos, 0);
			AddSibling(newEnemy);
		}
	}
}
