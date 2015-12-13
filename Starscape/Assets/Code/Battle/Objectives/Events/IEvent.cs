using UnityEngine;
using System.Collections;

interface IEvent
{
    void Fire();
    float TriggerTime { get; set; } // -1 will mean at the end of an objective.
}
