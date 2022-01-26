using System;
// using System.Collections.Generic;
using Godot;
using Godot.Collections;


class TestNode : Node2D
{
    [Export]
    private Array<int> _animations = new Array<int>(0, 0, 0, 0, 0, 0, 0, 0); 
    private Array<Vector2> _vectors = new Array<Vector2>(
        Vector2.Right, Vector2.One,
        Vector2.Down, new Vector2(-1, 1),
        Vector2.Left, new Vector2(-1, -1),
        Vector2.Up, new Vector2(1, -1)
    );

    private double _degreeStep;

    public override void _Ready()
    {
        base._Ready();

        _degreeStep = 360 / _animations.Count;

        foreach (var vector in _vectors)
        {
            Logger.Info(
                $"{vector.Normalized().Degree2Index(_degreeStep)}"
            );
        }
    }
}