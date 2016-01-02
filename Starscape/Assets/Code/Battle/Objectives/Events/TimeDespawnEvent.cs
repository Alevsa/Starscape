using UnityEngine;
using System.Collections;
using System;

public class TimeDespawnEvent : TimedEvent
{
    public GameObject[] Despawns;
    public override void Fire()
    {
        foreach (GameObject Despawn in Despawns)
            Despawn.SetActive(false);
    }

}
