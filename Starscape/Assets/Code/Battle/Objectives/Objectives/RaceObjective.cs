using UnityEngine;
using System.Collections;
using System;

public class RaceObjective : Objective
{
    public Transform Racer;
    public Collider FinishLine;

    public override void CheckCompletion()
    {
        if (FinishLine.bounds.Contains(Racer.position))
        {
            Completed = true;
        }
    }

    public override void CheckFailure()
    {
        if (TimeLimit < 0f && m_IsTimed)
        {
            Failed = true;
        }
    }
}
