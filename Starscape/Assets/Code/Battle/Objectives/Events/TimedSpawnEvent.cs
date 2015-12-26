using UnityEngine;
using System.Collections;

public class TimedSpawnEvent : TimedEvent
{
    public GameObject[] Spawns;

    void Start()
    {
        foreach (GameObject obj in Spawns)
        {
            obj.SetActive(false);
        }
    }

    public override void Fire()
    {
        foreach (GameObject Spawn in Spawns)
        {
            Debug.Log("Fired Spawn Event");
            Spawn.SetActive(true);
        }
    }
}
