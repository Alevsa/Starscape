using UnityEngine;
using System.Collections;
using System;

public class SpawnEvent : MissionEvent, IEvent
{
    public GameObject[] Spawns;
    public float TriggerTime { get; set; }

    void Start()
    {
        foreach (GameObject Spawn in Spawns)
        {
            Spawn.SetActive(false);
        }
    }

    public override void Fire()
    {
        foreach (GameObject Spawn in Spawns)
        {
            Spawn.SetActive(true);
        }
    }
}
