using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour
{
    public GameObject Projectile;
	public float Damage;
	public float Speed;
	public LayerMask HitLayers;

	public Transform FiringPoints;
    public float Ammo;
    public float FireRate;
    protected float m_Timer;
	
    void Update()
    {
        m_Timer += Time.deltaTime;
    }

    public virtual void Fire(List<Transform> firingPoints)
    {
    }

	protected virtual ProjectileParams SetProjectileParams()
	{
		ProjectileParams projParams = new ProjectileParams();
		projParams.Damage = Damage;
		projParams.Speed = Speed;
		projParams.Transform = transform;
		projParams.HitLayers = HitLayers;
		return projParams;
	}
}
