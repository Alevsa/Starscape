using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDogfighter : MonoBehaviour 
{
	private float m_DangerDistance;
	private ShipCore m_TargetCore;
	public LayerMask EnemyLayer;
	public Transform Focus;
	public Transform Pointer;
	private Transform m_Target;
	private ShipCore m_core;
	private BattleMovement m_BattleMovement;
	private WeaponController m_weapon;
	public Transform[] FiringPoints;
	public float MaxVariation = 1.5f;
	public float MinVariation = 0.7f;
	
	///
	/// TO DO:
	/// Make the distance check from the player more intelligent
	///
	void Start () 
	{
		m_TargetCore = Focus.GetComponent<ShipCore>();
		if (FiringPoints.Length == 0)
		{
			FiringPoints = new Transform[1];
			FiringPoints[0] = transform;
		}
		m_weapon = gameObject.GetComponent<WeaponController>();
		m_core = gameObject.GetComponent<ShipCore>();
		m_BattleMovement = gameObject.GetComponent<BattleMovement>();
		StatRandomiser(MaxVariation, MinVariation);
		m_DangerDistance = m_core.MaxSpeed * 0.02f;
		m_Target = Focus.GetComponent<Collider>().transform;
	}
	

	void FixedUpdate () 
	{
		if (Focus != null)
		{
			MovementControl();
			FireControl();
		}
		else Halt();
	}
	
	void FireControl()
	{
		foreach (Transform pos in FiringPoints)
		{
			//Debug.DrawLine(pos.position, transform.forward*400f, Color.white);
			if (Physics.Raycast(pos.position, transform.forward, Mathf.Infinity, EnemyLayer) && m_TargetCore.Alive)
			{
				m_weapon.FirePrimaryWeapon();
				break;
			}
		}
	}
	
	void MovementControl()
	{	
		if (Physics.Raycast(transform.position, transform.forward, m_DangerDistance, EnemyLayer))
		{
			EvasiveManoeuvers();
		}
		else if (Vector3.Distance(m_Target.transform.position, transform.position) > m_DangerDistance)
		{
			Pursue();
		}
		else 
		{
			SlowPursuit();
		}
	}
	
	void Halt()
	{
	//	Debug.Log("Breaking Off");
		m_BattleMovement.HandBrake();
	}
	
	void TurnToTarget()
	{
		Pointer.LookAt(m_Target);
		m_BattleMovement.TurnToward(Pointer.rotation);
	}
	
	void SlowPursuit()
	{
		TurnToTarget();
		m_BattleMovement.HandBrake();
	}
	
	void Pursue()
	{
	//	Debug.Log("In pursuit");
		TurnToTarget();
		m_BattleMovement.Accelerate();
	}
	
	void EvasiveManoeuvers()
	{
		m_BattleMovement.PitchYaw(ScannerSweep(30f, 30f, transform.right), ScannerSweep(30f, 30f, transform.up));
	}
	
	// Multiplying a vector by a quaternion rotates the vector, so basically we're sweeping the area to find somewhere clear to turn to
	float ScannerSweep(float angle, float increment, Vector3 axis)
	{
		if (increment * angle > 360f)
		{
			return 0f; 
		}
		Quaternion p = Quaternion.Euler(axis * angle);
		if (!Physics.Raycast(transform.position, p * transform.position, m_DangerDistance, EnemyLayer))
		{
			return 1f;
		}
		else if (!Physics.Raycast(transform.position, p * -transform.position , m_DangerDistance, EnemyLayer))
		{
			return -1f;
		}
		else if (!Physics.Raycast(transform.position, transform.position + transform.forward, m_DangerDistance, EnemyLayer))
		{
			return 0f;
		}
		else 
		{
			return ScannerSweep(angle + increment, increment++, axis);
		}
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
