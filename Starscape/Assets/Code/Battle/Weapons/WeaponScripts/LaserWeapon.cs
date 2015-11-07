using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserWeapon : Weapon
{
    public override void Fire(List<Transform> firingPoints)
    {
        if (m_Timer > FireRate)
        {
            for (int i = 0; i < 2; i++)
            {
                float playerSpeed = Mathf.Abs(GameObject.FindGameObjectWithTag("PlayerBattle").GetComponent<ShipCore>().Speed /100);
                GameObject proj = ObjectPooler.Current.GetPooledObject(PoolIndex);
                proj.GetComponent<Projectile>().SetParams(Damage, playerSpeed + Speed, firingPoints[i], HitLayers);
                proj.transform.Rotate(90, 0, 0);
                proj.SetActive(true);
            }

            m_Timer = 0;
        }
    }
}
