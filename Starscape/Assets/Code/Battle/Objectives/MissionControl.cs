using UnityEngine;
using System.Collections.Generic;

public class MissionControl : MonoBehaviour
{
    public Objective[] Objectives;
    public BonusObjective[] BonusObjectives;
    private List<Objective> m_ActiveObjectives;
    private int m_NumberOfStages = 0;
    public int m_CurrentStage = 0;

    void Start()
    {
        foreach (Objective obj in Objectives)
        {
            if (obj.Stage > m_NumberOfStages)
            {
                m_NumberOfStages = obj.Stage;
            } 
        }
        SetActiveObjectives();
    }

    void Update()
    {
        CheckStageCompletion();
        CheckStageFailure();
    }

    void SetActiveObjectives()
    {
        Debug.Log("Hello");
        m_ActiveObjectives.Clear();
        foreach (Objective obj in Objectives)
        {
            if (obj.Stage == m_CurrentStage)
            {
                m_ActiveObjectives.Add(obj);
                obj.Activate();
            }
            if (m_ActiveObjectives.Count == 0)
            {
                Win();
            }
        }
    }

    void CheckStageCompletion()
    {
        int count = 0;
        foreach (Objective obj in m_ActiveObjectives)
        {
            if (obj.Completed)
            {
                count++;
            }
        }
        if (count == m_ActiveObjectives.Count)
        {
            m_CurrentStage++;
            SetActiveObjectives();
        }
    }

    void CheckStageFailure()
    {
        foreach (Objective obj in m_ActiveObjectives)
        {
            if (obj.Failed)
            {
                MissionFailed();
            }
        }
    }

    void MissionFailed()
    {
        Debug.Log("Mission Failed");
    }
    void Win()
    {
            Debug.Log("You win");
    }
}
