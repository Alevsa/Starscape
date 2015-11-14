using UnityEngine;
using System.Collections;

public abstract class Objective : MonoBehaviour, IObjective
{
    public float TimeLimit = 120f;
    protected bool m_IsTimed;
    public int Stage;
    private Coroutine m_Timer;

    public bool Completed { get; set; }
    public bool Failed { get; set; }
    public int Priority { get; set; }
    public string DescriptiveName { get; set; }
    public bool Active { get; set; }

    public abstract void CheckCompletion();
    public abstract void CheckFailure();

    protected void Update()
    {
        CheckCompletion();
        CheckFailure();
    }

    protected IEnumerator Timer()
    {
        while (TimeLimit >= 0f)
        {
            TimeLimit -= Time.deltaTime;
            yield return null;
        }
    }

    public void Activate()
    {
        Debug.Log("Hello");
        Failed = false;
        Completed = false;
        if (TimeLimit > 0f)
        {
            m_IsTimed = true;
            m_Timer = StartCoroutine("Timer");
        }
        else
        {
            m_IsTimed = false;
        }
    }
}

