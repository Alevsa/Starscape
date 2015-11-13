using UnityEngine;
using System.Collections;

public abstract class TimedObjective : MonoBehaviour
{
    public float TimeLimit = 120f;
    protected bool m_IsTimed;
    private Coroutine m_Timer;

    protected virtual void Start()
    {
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

    protected IEnumerator Timer()
    {
        while (TimeLimit >= 0f)
        {
            TimeLimit -= Time.deltaTime;
            yield return null;
        }
    }
}
