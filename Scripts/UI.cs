using Godot;

public partial class UI : CanvasLayer
{
    [Export]
    public Label ScoreLabel;

    private int score;

    public override void _Ready()
    {
        base._Ready();

        Events.EnemyDestroyed += onEnemyDestroyed;
    }

    private void onEnemyDestroyed(Enemy destroyedEnemy)
    {
        increaseScore(destroyedEnemy.ScoreValue);
    }

    private void increaseScore(int scoreValue)
    {
        score += scoreValue;
        ScoreLabel.Text = score.ToString();
    }
}
