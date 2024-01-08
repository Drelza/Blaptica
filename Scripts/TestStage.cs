using System;
using Blaptica;
using Godot;

public partial class TestStage : Stage
{
	[Export]
	public PackedScene RedEnemyScene;

	[Export]
	public PackedScene BlueEnemyScene;

	[Export]
	public float Padding = 10;

	[Export]
    public double SpawnDelay = 1;

	private PackedScene[] enemies;

    public override void _Ready()
	{
		enemies = new PackedScene[] { RedEnemyScene, BlueEnemyScene };
		CreateTween().SetLoops().TweenCallback(Callable.From(SpawnRandomEnemy)).SetDelay(SpawnDelay);
		CreateTween().TweenCallback(Callable.From(EndStage)).SetDelay(10);
	}

	private void EndStage()
	{
		if (GameState.IsGameOver)
			return;

		GD.Print("Test Stage Complete");
		StageCompleted?.Invoke();
	}

    private void SpawnRandomEnemy()
    {
		var randomEnemyScene = enemies[GD.Randi() % enemies.Length];
		SpawnEnemy(randomEnemyScene);
    }

    private void SpawnEnemy(PackedScene enemyScene)
	{
		if (GameState.IsGameOver)
			return;

		var newEnemy = enemyScene.Instantiate<BaseEnemy>();
		float xPos = (float)GD.RandRange(0 + Padding, 540 - Padding);
		newEnemy.Position = new Vector2(xPos, 0);
		AddSibling(newEnemy);
	}

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}
