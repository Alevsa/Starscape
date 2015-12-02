﻿using UnityEngine;
using System.Collections;

public class StageDirector : MonoBehaviour
{
    private int m_ActiveStage;
    public GameObject[] MissionObjects;

    void Start ()
    {
        m_ActiveStage = SaveLoadController.GetStoryStage();
	}

    void setActiveMissions()
    {
        foreach (GameObject obj in MissionObjects)
        {
            obj.SetActive(false);
        }
        for (int i = 0; i < m_ActiveStage; i++)
        {
            MissionObjects[i].SetActive(true);
        }
    }
}