using System;
using Godot;

public partial class GameEvents : Node
{
    public delegate void EnemyDestroyedEventHandler(BaseEnemy destroyedEnemy);
    public static EnemyDestroyedEventHandler EnemyDestroyed;

    public delegate void PlayerDestroyedEventHandler(BaseEnemy killer);
    public static PlayerDestroyedEventHandler PlayerDestroyed;

    public delegate void GameOverEventHandler();
    public static GameOverEventHandler GameOver;

    public delegate void EnemyExitedEventHandler(BaseEnemy enemy);
    public static EnemyExitedEventHandler EnemyExited;
}
