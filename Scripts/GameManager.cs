using System;
using Godot;

namespace Blaptica;

public partial class GameManager : Node
{
    public override void _Ready()
    {
        base._Ready();        
        
        GameEvents.GameOver += OnGameOver;
        ScoreBar.Emptied += OnProgressBarEmptied;
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
