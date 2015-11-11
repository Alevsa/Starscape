using UnityEngine;
using System.Collections;

public class TargetingComputer : MonoBehaviour
{
    public string TargettedTag = "PlayerBattle";

    public Transform AquireTarget()
    {
        GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag(TargettedTag);
        if (potentialTargets.Length != 0)
        {
            return potentialTargets[Random.Range(0, potentialTargets.Length - 1)].transform;
        }
        else
        {
            return null;
        }
    }
}
