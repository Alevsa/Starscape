using UnityEngine;
using System.Collections;

public class PlayerLaserWeapon : LaserWeapon
{
    public override Vector3 SetDirection(Transform firingPoint)
    {
        Vector3 dir = firingPoint.forward;
        dir += firingPoint.right * (Input.GetAxis("Horizontal")/10);
        dir += firingPoint.up * (Input.GetAxis("Vertical")/10);
        dir.Normalize();
        return dir;
    }

}
