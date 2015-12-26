﻿using UnityEngine;
using System.Collections;
using System;

public abstract class TimedEvent : MissionEvent, IEvent
{
    public float TriggerTime { get; set; }
    private float m_Time;
    private bool m_Active = false;

    void Update()
    {
        if (m_Active)
        {
            Timer();
            if (m_Time > TriggerTime)
            {
                Fire();
                m_Active = false;
            }
        }
    }

    void IEvent.Activate()
    {
        m_Active = true;
    }

    void Timer()
    {
        m_Time += Time.deltaTime;
    }
}
