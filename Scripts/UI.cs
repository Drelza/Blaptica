using System;
using Godot;

public partial class UI : CanvasLayer
{
    [Export]
    public Label ScoreLabel;

    [Export]
    public Label GameOverLabel;

    private int score;

    public override void _Ready()
    {
        base._Ready();

        GameEvents.PlayerKilledEnemy += OnPlayerKilledEnemy;
        GameEvents.GameOver += OnPlayerDestroyed;
        GameEvents.EnemyExited += OnEnemyMissed;
    }

    private void OnEnemyMissed(BaseEnemy enemy)
    {
        UpdateScore(-enemy.ScoreValue);
    }

    private void OnPlayerKilledEnemy(int score)
    {
        UpdateScore(score);
    }

    private void OnPlayerDestroyed()
    {
        GameOverLabel.Visible = true;
        GameEvents.EnemyExited -= OnEnemyMissed;
    }

    private void UpdateScore(int scoreValue)
    {
        score += scoreValue;
        score = score < 0 ? 0 : score;
        ScoreLabel.Text = score.ToString();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        GameEvents.PlayerKilledEnemy -= OnPlayerKilledEnemy;
        GameEvents.GameOver -= OnPlayerDestroyed;
        GameEvents.EnemyExited -= OnEnemyMissed;
    }
}
