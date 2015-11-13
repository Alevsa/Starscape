using UnityEngine;
using System;

public class KillObjective : TimedObjective, IObjective
{  
    public bool Completed { get; set; }
    public bool Failed { get; set; }
    public GameObject[] Targets;
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void CheckCompletion()
    {
        throw new NotImplementedException();
    }

    public void CheckFailure()
    {
        if (TimeLimit < 0f && m_IsTimed)
        {
            Failed = true;
        }
    }
}
