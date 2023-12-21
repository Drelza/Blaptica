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

        Events.EnemyDestroyed += onEnemyDestroyed;
        Events.PlayerDestroyed += onPlayerDestroyed;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (Input.IsActionJustPressed("ui_accept"))
        {
            GetTree().ReloadCurrentScene();
        }
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        Events.EnemyDestroyed -= onEnemyDestroyed;
        Events.PlayerDestroyed -= onPlayerDestroyed;
    }

    private void onEnemyDestroyed(Enemy destroyedEnemy)
    {
        increaseScore(destroyedEnemy.ScoreValue);
    }

    private void onPlayerDestroyed(Enemy killer)
    {
        GameOverLabel.Visible = true;
    }

    private void increaseScore(int scoreValue)
    {
        score += scoreValue;
        ScoreLabel.Text = score.ToString();
    }    
}
