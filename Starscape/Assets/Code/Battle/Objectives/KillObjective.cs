using UnityEngine;
using System.Collections.Generic;

// Objective is to kill all the Targets, may or may not have atime limit.
public class KillObjective : Objective
{  
    public List<GameObject> Targets;

    public override void CheckCompletion()
    {
        if (Targets.Count == 0)
        {
            Completed = true;
        }
        else
        {
            foreach (GameObject target in Targets)
            {
                if (target == null)
                {
                    Targets.Remove(target);
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
