using UnityEngine;
using System.Collections;
using System.Linq;

public class ShipCore : ShipComponent
{	
	private ShipPeripheral[] m_ShipPeripherals;
    public ShipPeripheral[] AdditionalPeripherals;
	public override void Start () 
	{
		base.Start();
        m_ShipPeripherals = GetComponentsInChildren<ShipPeripheral>();
        m_ShipPeripherals.Concat(AdditionalPeripherals);
		Alive = true;
		foreach(ShipPeripheral peripheral in m_ShipPeripherals)
		{
			TurnRate += peripheral.TurnRate;
			Acceleration += peripheral.Acceleration;
			Deceleration += peripheral.Deceleration;
			MaxSpeed += peripheral.MaxSpeed;
			MaxHealth += peripheral.MaxHealth;
			MaxReverseSpeed += peripheral.MaxReverseSpeed;
			RollRate += peripheral.RollRate;
		}
	}
	
	void Update()
	{
		if (Health <= 0 && Alive)
			Die ();
	}
	
	void Die()
	{	
		//Debug.Log("Dead");
		WeaponController weapons = gameObject.GetComponent<WeaponController>();
		if (weapons != null)
		{
			weapons.Alive = false;
		}
		Alive = false;
		TurnRate = 0f;
		Acceleration = 0f;
		Deceleration = 0f;
		RollRate = 0f;
		DeathAnimation();
		//StartCoroutine("DeathAnimation");
	}
	
	protected override void DeathAnimation()
	{
	/*
		foreach (ShipPeripheral peripheral in m_ShipPeripherals)
		{
			peripheral.SwitchOffSmoke();
		}
	*/	
		base.DeathAnimation();
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		foreach (Renderer r in renderers)
		{
			r.enabled = false;
		}
		Collider[] collider = gameObject.GetComponentsInChildren<Collider>();
		foreach (Collider col in collider)
		{
			col.enabled = false;
		}
		//Destroy(gameObject);
	}
}
