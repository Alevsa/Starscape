using UnityEngine;
using System.Collections;

public class ShipPeripheral : ShipComponent 
{
	private ShipCore m_Core; 
	void Start()
	{
		m_Core = transform.GetComponentInParent<ShipCore>();
	}
	
	void Update()
	{
		if (Health <= 0f && Alive)
			Disabled();
	}
	
	public override void TakeDamage(float damage)
	{
		base.TakeDamage(damage);
		m_Core.TakeDamage(damage);
	}
	
	void Disabled()
	{
		Alive = false;
		m_Core.TurnRate -= TurnRate;
		m_Core.Acceleration -= Acceleration;
		m_Core.Deceleration -= Deceleration;
		m_Core.MaxSpeed -= MaxSpeed;
		m_Core.MaxHealth -= MaxHealth;
		m_Core.MaxReverseSpeed -= MaxReverseSpeed;
		m_Core.RollRate -= RollRate;
	}
	
}
