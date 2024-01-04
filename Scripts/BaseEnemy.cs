using Godot;

[GlobalClass]
public partial class BaseEnemy : Node2D
{
	[Export]
	public Area2D CollisionArea;

	[Export]
	public PackedScene LaserScene;

	[Export]
	public float Speed = 200;

	[Export]
	public float LaserInterval = 0.4f;

	[Export]
	public int ScoreValue = 1;

    [Export]
    public int MaxHealth = 1;

    protected Health health;
	private Timer timer;
	private VisibleOnScreenNotifier2D onScreenNotifier;

    public override void _Ready()
    {
        base._Ready();

        onScreenNotifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
        health = new Health(MaxHealth);

        CollisionArea.AreaEntered += OnBodyEntered;
		onScreenNotifier.ScreenExited += OnScreenExited;
		GameEvents.GameOver += OnGameOver;
        health.Depeleted += OnHealthDepleted;

        timer = new Timer
        {
            OneShot = false,
            Autostart = true,
            WaitTime = LaserInterval
        };

        AddChild(timer);
        timer.Timeout += Shoot;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        Move(delta);
    }

    private void Move(double delta)
    {
        var newPosition = Position;
        newPosition.Y += Speed * (float)delta;
        Position = newPosition;
    }

    protected void Shoot()
    {
		var laser = LaserScene.Instantiate<Laser>();
		laser.Position = Position;
        AddSibling(laser);
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

    private void OnHealthDepleted()
    {
        QueueFree();
        GameEvents.EnemyDestroyed?.Invoke(ScoreValue);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
		GameEvents.GameOver -= OnGameOver;
    }
}
