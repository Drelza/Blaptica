using System;
using Blaptica;
using Godot;

public partial class TestStage : Stage
{
	[Export]
	public PackedScene RedEnemyScene;

	[Export]
	public float Padding = 10;

	[Export]
    public double SpawnDelay = 1;

	private PackedScene[] enemies;

    public override void _Ready()
	{
		CreateTween().SetLoops().TweenCallback(Callable.From(()=>SpawnEnemy(RedEnemyScene))).SetDelay(SpawnDelay);
	}

    private void SpawnEnemy(PackedScene enemyScene)
	{
		if (GameState.IsGameOver)
			return;

		var newEnemy = enemyScene.Instantiate<EnemyShip>();
		float xPos = (float)GD.RandRange(0 + Padding, 540 - Padding);
		newEnemy.Position = new Vector2(xPos, 0);
		AddSibling(newEnemy);
	}
}
