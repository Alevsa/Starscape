using UnityEngine;
using System.Collections;

public abstract class CompleteEvent : MonoBehaviour, IEvent
{
    private IObjective m_Objective;

    void Start()
    {
        m_Objective = transform.GetComponent<IObjective>();
    }

    void Update()
    {
        if (m_Objective.Completed)
        {
            Fire();
        }
    }

    public abstract void Fire();

    public void Activate()
    {
    }
}
