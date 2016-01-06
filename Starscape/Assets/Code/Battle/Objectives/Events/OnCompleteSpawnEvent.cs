using UnityEngine;
using System.Collections;
using System;

public class OnCompleteSpawnEvent : CompleteEvent
{
    public GameObject[] Spawn;

    public override void Fire()
    {
        foreach (GameObject spawn in Spawn)
        {
            spawn.SetActive(true);
        }
    }
}
