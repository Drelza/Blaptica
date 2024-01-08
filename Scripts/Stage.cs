using Godot;

public partial class Stage : Node2D
{
    public delegate void StageCompleteEventHandler();
    public StageCompleteEventHandler StageCompleted;
}
