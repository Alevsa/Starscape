using UnityEngine;
using System.Collections.Generic;

public abstract class Objective : MonoBehaviour, IObjective
{
    public string FailureText = "You failed";
    public float TimeLimit = 120f;
    private float m_Time = 120f;
    protected bool m_IsTimed;
    public int Stage;
    private Coroutine m_Timer;
    public string MissionText;
    public List<MissionEvent> Events;
    private MissionEvent[] m_SortedEvents;
    private int ActiveEvent = 0;

    public bool Completed { get; set; }
    public bool Failed { get; set; }
    public int Priority { get; set; }
    public bool Active { get; set; }

    public abstract void CheckCompletion();
    public abstract void CheckFailure();

    void Start()
    {
        m_Time = TimeLimit;
        SortEvents();
    }

    protected void Update()
    {
        CheckEvents();
        CheckCompletion();
        CheckFailure();
        if (m_IsTimed)
        {
            Timer();
        }
    }

    protected void Timer()
    {
        m_Time -= Time.deltaTime;
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

    private void CheckEvents()
    {
        if (m_SortedEvents[ActiveEvent].TriggerTime < m_Time && ActiveEvent < m_SortedEvents.Length)
        {
            m_SortedEvents[ActiveEvent].Fire();
            ActiveEvent += 1;
            CheckEvents();
        }
    }

    private void SortEvents()
    {
        m_SortedEvents = new MissionEvent[Events.Count];
        foreach (MissionEvent ev in Events)
        {
            if (ev.TriggerTime < -1 || ev.TriggerTime > TimeLimit)
            {
                ev.TriggerTime = TimeLimit;
            }
        }
        for (int i = 0; i < Events.Count; i++)
        {
            int min = i;
            for (int j = i + 1; j < Events.Count; j++)
            {
                if (Events[j].TriggerTime < Events[min].TriggerTime)
                {
                    min = j;
                }
            }
            m_SortedEvents[i] = Events[min];
        }
    }
}

