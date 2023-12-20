using Godot;

public partial class Events : Node
{
    public delegate void EnemyDestroyedEventHandler(Enemy destroyedEnemy);
    public static EnemyDestroyedEventHandler EnemyDestroyed;
}
