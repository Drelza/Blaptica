using System;

namespace Blaptica;

public class GameState
{
    private static GameStates current;

    public static bool IsGameOver => current == GameStates.GAME_OVER;

    private enum GameStates
    {
        GAME_OVER, PLAYING
    }

    public static void SetPlaying()
    {
        current = GameStates.PLAYING;
    }

    internal static void SetGameOver()
    {
        current = GameStates.GAME_OVER;
    }
}
