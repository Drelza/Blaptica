using Godot;
using Blaptica;

public partial class Stage : Node2D
{
    public delegate void StageCompleteEventHandler();
    public StageCompleteEventHandler StageCompleted;

	protected void EndStage()
	{
		if (GameState.IsGameOver)
			return;

		StageCompleted?.Invoke();
	}
}
