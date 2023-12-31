using Godot;

public partial class EnemySpawner : Node2D
{
	[Export]
	public PackedScene RedEnemyScene;

	[Export]
	public PackedScene BlueEnemyScene;

	[Export]
	public float Padding = 10;

	private Timer timer;
	private bool enemiesCanSpawn;
	private PackedScene[] enemies;

	public override void _Ready()
	{
		enemies = new PackedScene[] { RedEnemyScene, BlueEnemyScene };
		enemiesCanSpawn = true;
		timer = GetNode("Timer") as Timer;

		timer.Timeout += OnTimerTimeOut;
		GameEvents.GameOver += OnGameOver;
	}

	private void OnGameOver()
	{
		enemiesCanSpawn = false;
	}

	private void OnTimerTimeOut()
	{
		SpawnRandomEnemy(enemies);
	}

    private void SpawnRandomEnemy(PackedScene[] enemies)
    {
		var randomEnemyScene = enemies[GD.Randi() % enemies.Length];
		SpawnEnemy(randomEnemyScene);
    }

    private void SpawnEnemy(PackedScene enemyScene)
	{
		if (enemiesCanSpawn)
		{
			var newEnemy = enemyScene.Instantiate<BaseEnemy>();
			float xPos = (float)GD.RandRange(0 + Padding, 540 - Padding);
			newEnemy.Position = new Vector2(xPos, 0);
			AddSibling(newEnemy);
		}
	}

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
		GameEvents.GameOver -= OnGameOver;
    }
}
