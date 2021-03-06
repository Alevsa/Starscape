﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour
{
	public float Damage;
	public float Speed;
	public LayerMask HitLayers;

    public float Ammo;
    public float FireRate;

    public int PoolIndex;

    protected GameObject m_User;
    protected float m_Timer;

    void Update()
    {
        m_Timer += Time.deltaTime;
    }

    public void SetParams(GameObject user)
    {
        m_User = user;
    }
	
	public bool CanFire()
	{
		if (m_Timer > FireRate)
			return true;
		else
            return false;
	}
	
    public virtual void Fire(List<Transform> firingPoints)
    {
    }
}
