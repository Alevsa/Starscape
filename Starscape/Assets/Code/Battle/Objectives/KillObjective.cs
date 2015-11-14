using UnityEngine;
using System.Collections.Generic;

// Objective is to kill all the Targets, may or may not have atime limit.
public class KillObjective : Objective
{  
    public List<GameObject> Targets;

    public override void CheckCompletion()
    {
        // Debug.Log(Targets.Count);
        if (Targets.Count == 0)
        {
            Completed = true;
        }
        else
        {
            for (int i = 0; i < Targets.Count; i++)
            {
                if (Targets[i] == null)
                {
                    Targets.RemoveAt(i);
                    break;
                }
            }
        }
    }

    public override void CheckFailure()
    {
        if (TimeLimit < 0f && m_IsTimed)
        {
            Failed = true;
        }
    }
}
