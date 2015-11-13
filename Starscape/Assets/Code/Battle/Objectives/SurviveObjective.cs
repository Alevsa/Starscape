using System;
using UnityEngine;

// Objective to keep the focus gameobject alive until the timer is over.

public class SurviveObjective: TimedObjective, IObjective
{
    public bool Completed { get; set; }
    public bool Failed { get; set; }
    private Coroutine m_Timer;
    public GameObject Focus;

	protected override void Start()
    {
        Failed = false;
        Completed = false;
        base.Start();
	}

    protected void Update()
    {
        CheckCompletion();
        CheckFailure();
    }

    public void CheckCompletion()
    {
        if (TimeLimit <= 0f)
        {
            StopCoroutine(m_Timer);
            Completed = true;
        }
    }

    public void CheckFailure()
    {
        if (Focus == null)
        {
            Failed = true;
        }
    }
}
