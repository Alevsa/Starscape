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
			Health += peripheral.Health;
		}
	}
	
	void Update()
	{
	
	}
	
	void Die()
	{
	
	}
}
