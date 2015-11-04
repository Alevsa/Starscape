using UnityEngine;
using System.Collections;

public class ShipCore : ShipComponent
{
	public GameObject Explosion;
	private ShipPeripheral[] m_ShipPeripherals; 
	void Start () 
	{
		m_ShipPeripherals = GetComponentsInChildren<ShipPeripheral>();
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
		Debug.Log("Dead");
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
		GameObject deathExplosion = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
		deathExplosion.transform.SetParent(transform);
		
		//StartCoroutine("DeathAnimation");
	}
	/*
	IEnumerator DeathAnimation()
	{
		for (float i = 0; i < DeathExplosions; i+= Time.deltaTime)
		{
			
		}
	}*/
}
