﻿using UnityEngine;
using System.Collections;

abstract public class ShipComponent : MonoBehaviour 
{
	public float TurnRate;
	public float Acceleration;
	public float Deceleration;
	public float MaxSpeed;
	public float MaxReverseSpeed;
	public float MaxHealth;
	public float Health;
	public float Armour;
	public bool Alive;
	[HideInInspector]public float Speed;
	public float RollRate;
	
	public virtual void TakeDamage(float damage)
	{
		Health -= damage;
	}
}
