using Blaptica;
using Godot;
using System;

public partial class Main : Node
{
    public override void _Ready()
    {
        base._Ready();

        GameState.SetPlaying();
        
        GameEvents.GameOver += OnGameOver;
        ScoreBar.Emptied += OnProgressBarEmptied;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        handleInput();
    }

    private void handleInput()
    {
        if (GameState.IsGameOver && Input.IsActionJustPressed("ui_accept"))
        {
            GetTree().ReloadCurrentScene();
        }
    }

    private void OnProgressBarEmptied()
    {
        GameEvents.GameOver?.Invoke();
    }

    private void OnGameOver()
    {
        GameState.SetGameOver();
    }
}
