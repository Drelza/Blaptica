using Godot;
using Blaptica;

[GlobalClass]
public partial class Stage : Node2D
{
    public delegate void StageCompleteEventHandler();
    public StageCompleteEventHandler StageCompleted;

    public override void _Ready()
    {
        base._Ready();
		GD.Print("Stage Ready");
    }

    protected void EndStage()
	{
		if (GameState.IsGameOver)
			return;

		StageCompleted?.Invoke();
	}
}
