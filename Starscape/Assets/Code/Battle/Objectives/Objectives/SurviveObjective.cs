using System;
using UnityEngine;

// Objective to keep the focus gameobject alive until the timer is over.

public class SurviveObjective: Objective, IObjective
{
    private Coroutine m_Timer;
    public GameObject Focus;

    public override void CheckCompletion()
    {
        if (TimeLimit <= 0f)
        {
            Completed = true;
        }
    }

    public override void CheckFailure()
    {
        if (Focus == null)
        {
            Failed = true;
        }
    }
}
