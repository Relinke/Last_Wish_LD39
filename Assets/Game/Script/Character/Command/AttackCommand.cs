using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{
    public override void Execute(Actor actor)
    {
        base.Execute(actor);
        actor.Attack();
    }
}