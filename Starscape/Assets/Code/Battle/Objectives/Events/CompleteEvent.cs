using UnityEngine;
using System.Collections;

public abstract class CompleteEvent : MonoBehaviour, IEvent
{
    private IObjective m_Objective;
    private bool m_Fired = false;
    void Start()
    {
        m_Objective = transform.GetComponent<IObjective>();
    }

    void Update()
    {
        if (m_Objective.Completed && !m_Fired)
        {
            m_Fired = true;
            Fire();
        }
    }

    public abstract void Fire();

    public void Activate()
    {
    }
}
