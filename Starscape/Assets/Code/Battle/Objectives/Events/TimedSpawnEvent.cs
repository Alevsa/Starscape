using UnityEngine;
using System.Collections;

public class TimedSpawnEvent : TimedEvent
{
    public GameObject[] Spawns;
    public override void Fire()
    {
        foreach (GameObject Spawn in Spawns)
        {
            Debug.Log("Fired Spawn Event");
            Spawn.SetActive(true);
        }
    }
}
