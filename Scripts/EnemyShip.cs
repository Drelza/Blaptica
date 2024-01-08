using Godot;
using System;

public partial class EnemyShip : Ship
{
	[Export]
	public float Speed = 200;

	[Export]
	public float LaserInterval = 0.4f;

	[Export]
	public int ScoreValue = 1;

    [Export]
    public int MaxHealth = 1;

    protected Health health;
	protected VisibleOnScreenNotifier2D onScreenNotifier;

    public override void _Ready()
    {
        base._Ready();

        onScreenNotifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
        health = new Health(MaxHealth);
        health.Depeleted += OnHealthDepleted;
		GameEvents.GameOver += OnGameOver;
		onScreenNotifier.ScreenExited += OnScreenExited;
        CollisionArea.AreaEntered += OnBodyEntered;
        CreateTween().SetLoops().TweenCallback(Callable.From(Shoot)).SetDelay(LaserInterval);
    }

    protected void Move(double delta, Vector2 direction)
    {
        Position += Speed * direction.Normalized() * (float)delta;
    }

    private void OnHealthDepleted()
    {
        QueueFree();
        GameEvents.EnemyDestroyed?.Invoke(ScoreValue);
    }
    
    private void OnGameOver()
    {
		QueueFree();
    }

    private void OnScreenExited()
    {
		GameEvents.EnemyExited?.Invoke(ScoreValue);
        CreateTween().TweenCallback(Callable.From(QueueFree)).SetDelay(1f);
    }

    private void OnBodyEntered(Node2D body)
	{
        if (body.GetParent() is Laser)
        {
            var damage = body.GetParent<Laser>().Damage;
            health.TakeDamage(damage);            
        }
	}

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
		GameEvents.GameOver -= OnGameOver;
    }
}
