using UnityEngine;
using System.Collections;

public abstract class TimedEvent : MonoBehaviour, IEvent
{
    public float TriggerTime { get; set; }
    private float Time;
    private bool m_Active = false;

    void Update()
    {
        if (m_Active)
            Timer();
        if (Time > TriggerTime)
            Fire();    
    }

    void Activate()
    {
        m_Active = true;
    }

    void Timer()
    {
        Time += Time.DeltaTime;
    }

    public abstract void Fire();

}
