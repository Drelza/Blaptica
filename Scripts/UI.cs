using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Godot;

public partial class UI : CanvasLayer
{
    [Export]
    public Control GameOverContainer;

    [Export]
    public ScoreBar ScoreBar;

    [Export]
    public Label ScoreLabel;

    public override void _Ready()
    {
        base._Ready();

        GameEvents.GameOver += OnGameOver;
    }

    #region EventListeners

    private void OnGameOver()
    {
        GameOverContainer.Visible = true;
        ScoreLabel.Text = $"Score: {ScoreBar.Score}";
    }

    #endregion

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        GameEvents.GameOver -= OnGameOver;
    }
}
