﻿using UnityEngine;
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
    public IEvent[] Events;

    public bool Completed { get; set; }
    public bool Failed { get; set; }
    public int Priority { get; set; }
    public bool Active { get; set; }

    public abstract void CheckCompletion();
    public abstract void CheckFailure();

    void Start()
    {
        //Events = transform.GetComponents<IEvent>();
        m_Time = TimeLimit;
    }

    protected void Update()
    {
        if (Active)
        {
            CheckCompletion();
            CheckFailure();
            if (m_IsTimed)
            {
                Timer();
            }
        }
    }

    protected void Timer()
    {
        m_Time -= Time.deltaTime;
    }

    public void Activate()
    {
        Events = transform.GetComponents<IEvent>();
        Failed = false;
        Completed = false;
        Active = true;
        if (TimeLimit > 0f)
        {
            m_IsTimed = true;
        }
        else
        {
            m_IsTimed = false;
        }
        if (Events != null)
        {
            foreach (IEvent ev in Events)
            {
                Debug.Log("Activating event");
                ev.Activate();
            }
        }
    }
}

