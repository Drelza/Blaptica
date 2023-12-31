using System;
using System.Diagnostics.Tracing;
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

	private Timer timer;
	private VisibleOnScreenNotifier2D onScreenNotifier;

	public override void _Ready()
	{
		base._Ready();

		onScreenNotifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");

		CollisionArea.AreaEntered += OnBodyEntered;
		onScreenNotifier.ScreenExited += OnScreenExited;
		GameEvents.GameOver += OnGameOver;

        timer = new Timer
        {
            OneShot = false,
            Autostart = true,
            WaitTime = LaserInterval
        };

		AddChild(timer);
		timer.Timeout += Shoot;
    }

    private void OnGameOver()
    {
		QueueFree();
    }


    private void OnScreenExited()
    {
		// TODO: Delay with Tween
		QueueFree();
		GameEvents.EnemyExited?.Invoke(ScoreValue);
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

    private void OnBodyEntered(Node2D body)
	{
		QueueFree();
		
		if (body.GetParent() is Laser)
			GameEvents.PlayerKilledEnemy?.Invoke(ScoreValue);
	}

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
		GameEvents.GameOver -= OnGameOver;
    }
}
