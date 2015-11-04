﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDogfighter : MonoBehaviour 
{
	public LayerMask EnemyLayer;
	public Transform focus;
	public Transform Pointer;
	private ShipCore m_core;
	private BattleMovement m_BattleMovement;
	private WeaponController m_weapon;
	
	void Start () 
	{
		m_weapon = gameObject.GetComponent<WeaponController>();
		m_core = gameObject.GetComponent<ShipCore>();
		m_BattleMovement = gameObject.GetComponent<BattleMovement>();
	}
	

	void FixedUpdate () 
	{
		MovementControl();
		FireControl();
	}
	
	void FireControl()
	{
		if (Physics.Raycast(transform.position, transform.forward, Mathf.Infinity, EnemyLayer))
		{
			m_weapon.FirePrimaryWeapon();
		}
	}
	
	void MovementControl()
	{
		float stopTime = (m_core.Speed * Time.fixedDeltaTime) / (m_core.Deceleration * Time.fixedDeltaTime);
		float distance = 0.5f * ((m_core.Speed * Time.fixedDeltaTime) / stopTime);
		Debug.DrawLine(transform.position, transform.forward*distance, Color.white);
		if (Physics.Raycast(transform.position, transform.forward * distance, EnemyLayer))
			BreakOff();
		else
			Pursue();
	}
	
	
	void BreakOff()
	{
		Debug.Log("Breaking Off");
		m_BattleMovement.Decelerate();
	}
	
	void Pursue()
	{
		Debug.Log("In pursuit");
		Pointer.LookAt(focus);
		m_BattleMovement.TurnToward(Pointer.rotation);
		m_BattleMovement.Accelerate();
	}
	
	public void MoveToPoint()
	{
	
	}
}
