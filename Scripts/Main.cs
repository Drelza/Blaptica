using Blaptica;
using Godot;

public partial class Main : Node
{
    [Export]
    public PackedScene Stage;

    public override void _Ready()
    {
        base._Ready();

        LoadStage(Stage.Instantiate<Stage>());
    }

    private void LoadStage(Stage stage)
    {
        AddChild(stage);
    }
}
