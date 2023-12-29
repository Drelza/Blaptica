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

        GameEvents.EnemyDestroyed += onEnemyDestroyed;
        GameEvents.GameOver += onPlayerDestroyed;
        GameEvents.EnemyExited += onEnemyMissed;
    }

    private void onEnemyMissed(BaseEnemy enemy)
    {
        updateScore(-enemy.ScoreValue);
    }


    private void onEnemyDestroyed(BaseEnemy destroyedEnemy)
    {
        updateScore(destroyedEnemy.ScoreValue);
    }

    private void onPlayerDestroyed()
    {
        GameOverLabel.Visible = true;
        GameEvents.EnemyExited -= onEnemyMissed;
    }

    private void updateScore(int scoreValue)
    {
        score += scoreValue;
        score = score < 0 ? 0 : score;
        ScoreLabel.Text = score.ToString();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        GameEvents.EnemyDestroyed -= onEnemyDestroyed;
        GameEvents.GameOver -= onPlayerDestroyed;
        GameEvents.EnemyExited -= onEnemyMissed;
    }
}
