using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public partial class FirstStage : Stage
{
    [Export]
    public PackedScene[] WaveScenes;

    private List<Wave> waves;

    public override void _Ready()
    {
        base._Ready();
        waves = WaveScenes.Select(w => w.Instantiate<Wave>()).ToList();
        TryLoadNextWave();
    }

    private bool TryLoadNextWave()
    {
        if (waves.Count == 0)
            return false;

        AddChild(waves.First());
        waves.RemoveAt(0);
        return true;
    }
}