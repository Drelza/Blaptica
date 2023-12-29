using Godot;
using System;

public partial class GameManager : Node
{
    public static bool IsGameOver => gameState == GameState.GAME_OVER;

    private enum GameState
    {
        GAME_OVER, PLAYING
    }

    private static GameState gameState;

    public override void _Ready()
    {
        base._Ready();

        gameState = GameState.PLAYING;

        GameEvents.PlayerDestroyed += OnPlayerDestroyed;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        handleInput();
    }

    private void handleInput()
    {
        if (IsGameOver && Input.IsActionJustPressed("ui_accept"))
        {
            GetTree().ReloadCurrentScene();
        }
    }

    private void OnPlayerDestroyed(BaseEnemy killer)
    {
        gameState = GameState.GAME_OVER;

        GameEvents.GameOver?.Invoke();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        GameEvents.PlayerDestroyed -= OnPlayerDestroyed;
    }
}
