using UnityEngine;
using System.Collections;

interface IEvent
{
    void OnTrigger();
    float TriggerTime { get; set; } // -1 will mean at the end of an objective.
}
