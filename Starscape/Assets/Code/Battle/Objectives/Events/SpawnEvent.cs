using UnityEngine;
using System.Collections;

public class SpawnEvent : MonoBehaviour, IEvent
{
    public GameObject[] Spawns;
    public Transform SpawnLocation;
    public float SpawnCooldown = 2f;
    public float TriggerTime { get; set; }
    public void OnTrigger()
    {
        float i = 0;
        foreach (GameObject spawn in Spawns)
        {
            Invoke("Instantiate(spawn, SpawnLocation.position, Quaternion.identity)", i);
            i += 2f;
        }
    }
}
