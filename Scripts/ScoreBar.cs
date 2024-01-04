using Godot;
using System;

public partial class ScoreBar : ProgressBar
{
    public double Score { get; private set; }

    public delegate void EmptiedEventHandler();
    public static EmptiedEventHandler Emptied;    

    public override void _Ready()
    {
        base._Ready();

        GameEvents.EnemyExited += OnEnemyMissed;
        GameEvents.EnemyDestroyed += OnPlayerKilledEnemy;
        GameEvents.PlayerHit += OnPlayerHit;
        ValueChanged += OnProgressBarValueChanged;
    }

    public void Increase(double ammount)
    {
        Value += ammount;
        Score += ammount;
    }

    public void Decrease(double ammount)
    {
        if (ammount < 0)
            throw new ArgumentException(nameof(ammount) + "must be positive");
        
        Value -= ammount;
    }

    #region EventListeners

    private void OnEnemyMissed(double enemyScoreValue)
    {
        Decrease(enemyScoreValue);
    }

    private void OnPlayerHit()
    {
        Decrease(2);
    }

    private void OnPlayerKilledEnemy(double enemyScoreValue)
    {
        Increase(enemyScoreValue);
    }

    private void OnProgressBarValueChanged(double value)
    {
        if (value == 0)
            Emptied?.Invoke();
    }

    #endregion

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        GameEvents.EnemyExited -= OnEnemyMissed;
        GameEvents.EnemyDestroyed -= OnPlayerKilledEnemy;
        GameEvents.PlayerHit -= OnPlayerHit;
    }
}
