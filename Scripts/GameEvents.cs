using System;
using Godot;

public partial class GameEvents : Node
{
    /// <param name="score">Enemy point value</param>
    public delegate void PlayerKilledEnemyEventHandler(int score);

    /// <summary>
    /// Fired whenever the player kills an enemy through legitimate means
    /// </summary>
    public static PlayerKilledEnemyEventHandler PlayerKilledEnemy;

    public delegate void PlayerDestroyedEventHandler(BaseEnemy killer);
    public static PlayerDestroyedEventHandler PlayerDestroyed;

    public delegate void GameOverEventHandler();
    public static GameOverEventHandler GameOver;

    public delegate void EnemyExitedEventHandler(BaseEnemy enemy);
    public static EnemyExitedEventHandler EnemyExited;
}
