﻿using UnityEngine;
using System.Collections;

abstract public class ShipComponent : MonoBehaviour 
{
	public float TurnRate;
	public float Acceleration;
	public float Deceleration;
	public float MaxSpeed;
	public float MaxReverseSpeed;
	public float Health;
	public float Armour;
	[HideInInspector]public float Speed;
	public float RollRate;
	
	
	
	// On collider enter event to take damage will go here.
	// 
	//OnColl
}
