using System;
using Godot;

public partial class GameEvents : Node
{
    /// <param name="enemyScoreValue">Enemy point value</param>
    public delegate void PlayerKilledEnemyEventHandler(double enemyScoreValue);

    /// <summary>
    /// Fired whenever the player kills an enemy through legitimate means
    /// </summary>
    public static PlayerKilledEnemyEventHandler EnemyDestroyed;

    public delegate void GameOverEventHandler();
    public static GameOverEventHandler GameOver;

    public delegate void EnemyExitedEventHandler(double enemyScoreValue);
    public static EnemyExitedEventHandler EnemyExited;

    public delegate void PlayerHitEventHandler();
    public static PlayerHitEventHandler PlayerHit;
}
