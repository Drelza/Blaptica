using Godot;

namespace Blaptica;

public partial class GameManager : Node
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

        HandleInput();
    }

    private void HandleInput()
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
