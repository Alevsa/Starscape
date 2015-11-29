using UnityEngine;
using System.Collections;

public class StageDirector : MonoBehaviour
{
    private int m_ActiveStage;
    public GameObject MissionObjects[];

    void Start ()
    {
        m_ActiveStage = SaveLoadController.GetStoryStage();
	}
}
