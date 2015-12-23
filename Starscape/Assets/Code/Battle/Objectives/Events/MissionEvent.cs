using UnityEngine;
using System.Collections;

public abstract class MissionEvent : MonoBehaviour
{
    public abstract void Fire();
    public float TriggerTime = 0f;
}
