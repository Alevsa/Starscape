using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour
{
    public GameObject Projectile;
	public float Damage;
	public float Speed;
	public LayerMask HitLayers;

    public float Ammo;
    public float FireRate;
    protected float m_Timer;
	
    void Update()
    {
        m_Timer += Time.deltaTime;
    }
	
	public bool ICanFire()
	{
		if (m_Timer > FireRate)
			return true;
		else return false;
	}
	
    public virtual void Fire(List<Transform> firingPoints)
    {
    }
}
