using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    public Transform Focus;
    public ShipCore Core;
    public Transform Pointer;

    void FixedUpdate()
    {
    }

    void AlignTurret()
    {
        transform.LookAt(Focus);
        Pointer.LookAt(Focus);
    }
}
