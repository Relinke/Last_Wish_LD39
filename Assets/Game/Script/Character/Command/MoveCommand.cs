using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private float _x;

    public MoveCommand Init(float x)
    {
        _x = x;
        return this;
    }

    public override void Execute(Actor actor)
    {
        base.Execute(actor);
        actor.Move(_x);
    }
}
