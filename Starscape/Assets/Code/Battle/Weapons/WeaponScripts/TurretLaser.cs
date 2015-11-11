using UnityEngine;
using System.Collections.Generic;

public class TurretLaser : Weapon
{
    public override void Fire(List<Transform> firingPoints)
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject proj = ObjectPooler.Current.GetPooledObject(PoolIndex);
            proj.GetComponent<Projectile>().SetParams(Damage, Speed, SetDirection(firingPoints[i]), firingPoints[i], HitLayers);
            proj.transform.Rotate(90, 0, 0);
            proj.SetActive(true);
        }

        m_Timer = 0;
    }

    public virtual Vector3 SetDirection(Transform firingPoint)
    {
        return firingPoint.forward;
    }
}
