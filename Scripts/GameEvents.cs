using System;
using Godot;

public partial class GameEvents : Node
{
    public delegate void EnemyDestroyedEventHandler(Enemy destroyedEnemy);
    public static EnemyDestroyedEventHandler EnemyDestroyed;

    public delegate void PlayerDestroyedEventHandler(Enemy killer);
    public static PlayerDestroyedEventHandler PlayerDestroyed;

    public delegate void GameOverEventHandler();
    public static GameOverEventHandler GameOver;
}
