using Blaptica;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Handles Loading/Unloading Stages
/// </summary>
public partial class StageLoader : Node2D
{
    [Export]
    public PackedScene[] StageScenes;

    private Queue<Stage> queue;
    private Stage currentStage;

    public override void _Ready()
    {
        queue = new Queue<Stage>(StageScenes.Select(s => s.Instantiate<Stage>()));
        base._Ready();
        LoadNextStage();
    }

    private void OnStageComplete()
    {
        ChangeToNextStage();
    }

    private void ChangeToNextStage()
    {
        if (queue.Count == 0 || GameState.IsGameOver)
            return;

        GD.Print("Change to next stage");
        UnloadCurrentStage();
        LoadNextStage();    
    }

    private void LoadNextStage()
    {
        var dequeueSuccess = queue.TryDequeue(out currentStage);
        
        if (!dequeueSuccess || GameState.IsGameOver)
            return;

        GD.Print("Load next stage");
        currentStage.StageCompleted += OnStageComplete;
        AddChild(currentStage);
    }

    private void UnloadCurrentStage()
    {
        GD.Print("Unload Current Stage");
        currentStage.StageCompleted -= OnStageComplete;
        currentStage?.QueueFree();
    }
}
