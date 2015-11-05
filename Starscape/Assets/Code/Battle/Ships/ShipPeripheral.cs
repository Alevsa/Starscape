using UnityEngine;
using System.Collections;

public class ShipPeripheral : ShipComponent 
{
	private ShipCore m_Core; 
	private ParticleSystem[] m_SmokeEffects;
	
	public override void Start()
	{	
		base.Start();
		m_SmokeEffects = GetComponentsInChildren<ParticleSystem>();
		Alive = true;
		m_Core = transform.GetComponentInParent<ShipCore>();
		SwitchOffSmoke();
	}
	
	void FixedUpdate()
	{
		if (Health <= 0f && Alive)
			Disabled();
	}
	
	public override void TakeDamage(float damage)
	{
		base.TakeDamage(damage);
		Debug.Log("hit");
		m_Core.TakeDamage(damage);
	}
	
	void Disabled()
	{
		Alive = false;
		m_Core.TurnRate -= TurnRate;
		m_Core.Acceleration -= Acceleration;
		m_Core.Deceleration -= Deceleration;
		m_Core.MaxSpeed -= MaxSpeed;
		m_Core.MaxReverseSpeed -= MaxReverseSpeed;
		m_Core.RollRate -= RollRate;
		DeathAnimation();
	}
	
	public void SwitchOffSmoke()
	{
		foreach (ParticleSystem smoke in m_SmokeEffects)
		{
			smoke.enableEmission = false;
		}
	}
	
	protected override void DeathAnimation()
	{
		base.DeathAnimation();
		if (m_SmokeEffects != null)
		{
			foreach (ParticleSystem smoke in m_SmokeEffects)
			{
				smoke.enableEmission = true;
			}
		}
	}
}
