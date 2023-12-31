using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Godot;

public partial class UI : CanvasLayer
{
    [Export]
    public Label GameOverLabel;

    [Export]
    public ProgressBar ProgressBar;

    public override void _Ready()
    {
        base._Ready();

        GameEvents.PlayerKilledEnemy += OnPlayerKilledEnemy;
        GameEvents.GameOver += OnGameOver;
        GameEvents.EnemyExited += OnEnemyMissed;
        GameEvents.PlayerHit += OnPlayerHit;
        ProgressBar.ValueChanged += OnProgressBarValueChanged;
    }

    #region EventListeners

    private void OnProgressBarValueChanged(double value)
    {
        if (value == 0)
            GameEvents.GameOver?.Invoke();
    }

    private void OnEnemyMissed(double enemyScoreValue)
    {
        ProgressBar.Value -= enemyScoreValue;
    }

    private void OnPlayerKilledEnemy(double enemyScoreValue)
    {
        ProgressBar.Value += enemyScoreValue;
    }

    private void OnPlayerHit()
    {
        ProgressBar.Value -= 2;
    }

    private void OnGameOver()
    {
        GameOverLabel.Visible = true;
    }

    #endregion

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        GameEvents.PlayerKilledEnemy -= OnPlayerKilledEnemy;
        GameEvents.GameOver -= OnGameOver;
        GameEvents.EnemyExited -= OnEnemyMissed;
        GameEvents.PlayerHit -= OnPlayerHit;
    }
}
