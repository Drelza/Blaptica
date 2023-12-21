using Godot;

public partial class GameEvents : Node
{
    public delegate void EnemyDestroyedEventHandler(Enemy destroyedEnemy);
    public static EnemyDestroyedEventHandler EnemyDestroyed;

    public delegate void PlayerDestroyedEventHandler(Enemy killer);
    public static PlayerDestroyedEventHandler PlayerDestroyed;
}
