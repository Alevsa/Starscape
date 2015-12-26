using UnityEngine;
using System.Collections;

public abstract class MissionEvent : MonoBehaviour, IEvent
{
    // This is a hack that works around me not being able to directly make a list of type IEvent
    public virtual void Activate()
    {
    }
    public virtual void Fire()
    {
    }
}
