using UnityEngine;
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
	public Transform[] FiringPoints;
	public float MaxVariation = 1.5f;
	public float MinVariation = 0.7f;
		
	void Start () 
	{
		if (FiringPoints.Length == 0)
		{
			FiringPoints = new Transform[1];
			FiringPoints[0] = transform;
		}
		m_weapon = gameObject.GetComponent<WeaponController>();
		m_core = gameObject.GetComponent<ShipCore>();
		m_BattleMovement = gameObject.GetComponent<BattleMovement>();
		StatRandomiser(MaxVariation, MinVariation);
	}
	

	void FixedUpdate () 
	{
		MovementControl();
		FireControl();
	}
	
	void FireControl()
	{
		foreach (Transform pos in FiringPoints)
		{
			Debug.DrawLine(pos.position, transform.forward*400f, Color.white);
			if (Physics.Raycast(pos.position, transform.forward, Mathf.Infinity, EnemyLayer))
			{
				m_weapon.FirePrimaryWeapon();
				break;
			}
		}
	}
	
	void MovementControl()
	{
		Debug.Log(m_core.Speed);
		float stopTime = (m_core.Speed * Time.fixedDeltaTime) / (m_core.Deceleration * Time.fixedDeltaTime);
		float distance = 0.5f * ((m_core.Speed * Time.fixedDeltaTime) / stopTime);
		
		if (Physics.Raycast(transform.position, transform.forward * distance, EnemyLayer))
			BreakOff();
		else
			Pursue();
	}
	
	
	void BreakOff()
	{
		//Debug.Log("Breaking Off");
		m_BattleMovement.Decelerate();
	}
	
	void Pursue()
	{
		//Debug.Log("In pursuit");
		Pointer.LookAt(focus);
		m_BattleMovement.TurnToward(Pointer.rotation);
		m_BattleMovement.Accelerate();
	}
	
	public void StatRandomiser(float min, float max)
	{
		m_core.Acceleration *= Random.Range(min, max);
		m_core.Deceleration *= Random.Range(min, max);  
		m_core.MaxSpeed  *= Random.Range(min, max);  
		m_core.TurnRate *= Random.Range(min, max);  
		m_core.MaxHealth *= Random.Range(min, max);  
		m_core.MaxReverseSpeed *= Random.Range(min, max);  
		
	}
	
	public void MoveToPoint()
	{
	
	}
}
