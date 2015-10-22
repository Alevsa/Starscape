using UnityEngine;
using System.Collections;

public class ShipCore : ShipComponent
{
	private ShipPeripheral[] m_ShipPeripherals; 
	void Start () 
	{
		m_ShipPeripherals = GetComponentsInChildren<ShipPeripheral>();
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
		Alive = false;
		TurnRate = 0f;
		Acceleration = 0f;
		Deceleration = 0f;
		RollRate = 0f;
	}
}
