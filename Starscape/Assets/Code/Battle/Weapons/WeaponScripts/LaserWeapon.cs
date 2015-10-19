﻿using UnityEngine;
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
                GameObject proj = ObjectPooler.Current.GetPooledObject(0);
                proj.transform.position = firingPoints[i].position;
                proj.transform.rotation = firingPoints[i].rotation;
                proj.SetActive(true);
            }

            m_Timer = 0;
        }
    }
}
