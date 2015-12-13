using UnityEngine;
using System.Collections;

public class MissionEvent : MonoBehaviour, IEvent
{
    public void Fire()
    {
    }
    public float TriggerTime { get; set; }
}
