using Godot;
using System;

public partial class EnemySpawner : Node2D
{
	[Export]
	public PackedScene Enemy;

	[Export]
	public float Padding = 10;

	private Timer timer => GetNode("Timer") as Timer;

	public override void _Ready()
	{
		timer.Timeout += onTimerTimeOut;
	}

    private void onTimerTimeOut()
    {
		Enemy newEnemy = Enemy.Instantiate() as Enemy;
		float xPos = (float)GD.RandRange(0+Padding,540-Padding);
		newEnemy.Position = new Vector2(xPos,0);
		AddSibling(newEnemy);
    }
}
