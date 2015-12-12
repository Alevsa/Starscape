using UnityEngine;
using System.Collections;

public abstract class Objective : MonoBehaviour, IObjective
{
    public string FailureText = "You failed";
    public float TimeLimit = 120f;
    protected bool m_IsTimed;
    public int Stage;
    private Coroutine m_Timer;
    public string MissionText;
    public Event[] Events;

    public bool Completed { get; set; }
    public bool Failed { get; set; }
    public int Priority { get; set; }
    public bool Active { get; set; }

    public abstract void CheckCompletion();
    public abstract void CheckFailure();

    protected void Update()
    {
        CheckCompletion();
        CheckFailure();
        if (m_IsTimed)
        {
            Timer();
        }
    }

    protected void Timer()
    {
        TimeLimit -= Time.deltaTime;
    }

    public void Activate()
    {
        Failed = false;
        Completed = false;
        if (TimeLimit > 0f)
        {
            m_IsTimed = true;
        }
        else
        {
            m_IsTimed = false;
        }
    }
}

