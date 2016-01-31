using UnityEngine;
using System.Collections;

public class StageDirector : MonoBehaviour
{
    private int m_ActiveStage;
    public IStage[] Stages;

    void Start ()
    {
        m_ActiveStage = SaveLoadController.GetStoryStage();
	}

    void setActiveMissions()
    {
        foreach (IStage stage in Stages)
        {
            stage.gameObject.SetActive(false);
        }
        for (int i = 0; i <= m_ActiveStage; i++)
        {
            Stages[i].gameObject.SetActive(true);
        }
    }

    public int GetActiveStage()
    {
        return m_ActiveStage;
    }
}
