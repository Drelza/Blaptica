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

        GameEvents.EnemyDestroyed += OnEnemyDestroyed;
        GameEvents.GameOver += OnPlayerDestroyed;
        GameEvents.EnemyExited += OnEnemyMissed;
    }

    private void OnEnemyMissed(BaseEnemy enemy)
    {
        UpdateScore(-enemy.ScoreValue);
    }


    private void OnEnemyDestroyed(BaseEnemy destroyedEnemy)
    {
        UpdateScore(destroyedEnemy.ScoreValue);
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

        GameEvents.EnemyDestroyed -= OnEnemyDestroyed;
        GameEvents.GameOver -= OnPlayerDestroyed;
        GameEvents.EnemyExited -= OnEnemyMissed;
    }
}
