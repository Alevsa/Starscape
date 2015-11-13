using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TargetingComputer : MonoBehaviour
{
    public string[] TargetedTag;
    public Transform Focus;

    public Transform AquireTarget()
    {
        GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag(TargetedTag[0]);
        for (int i = 1; i < TargetedTag.Length; i++)
        {
            potentialTargets = potentialTargets.Concat(GameObject.FindGameObjectsWithTag(TargetedTag[i])).ToArray();
        }
        if (potentialTargets.Length > 0)
        {
           
            Transform target = potentialTargets[Random.Range(0, potentialTargets.Length)].transform;
            return target;
        }
        else
        {
            return null;
        }
    }

    void Update()
    {
        if (Focus == null)
        {
            Focus = AquireTarget();
        }
    }
}
