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

        Events.PlayerDestroyed += onPlayerDestroyed;
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


    private void onPlayerDestroyed(Enemy killer)
    {
        gameState = GameState.GAME_OVER;
    }

}
