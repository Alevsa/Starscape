using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDogfighter : MonoBehaviour 
{
	private float m_DangerDistance;
	private ShipCore m_TargetCore;
	public LayerMask PathingLayer;
	public LayerMask WeaponsLayer;
	public Transform Focus;
	public Transform Pointer;
	private ShipCore m_core;
	private BattleMovement m_BattleMovement;
	private WeaponController m_Weapon;
	public Transform[] FiringPoints;
	public float MaxVariation = 1.5f;
	public float MinVariation = 0.7f;
	public float SearchResolution = 3f;
	public float FindPathFrequency = 10f;
	private bool m_InMotion;
	private Collider[] m_CoreCollider;
	private float m_CastOffset;
	
	///
	/// TO DO:
	/// Make it work
	///
	void Start () 
	{
		m_TargetCore = Focus.GetComponent<ShipCore>();
		if (FiringPoints.Length == 0)
		{
			FiringPoints = new Transform[1];
			FiringPoints[0] = transform;
		}
		m_Weapon = gameObject.GetComponent<WeaponController>();
		m_core = gameObject.GetComponent<ShipCore>();
		m_BattleMovement = gameObject.GetComponent<BattleMovement>();
		
		m_CoreCollider = gameObject.GetComponentsInChildren<Collider>();
		m_CastOffset = GetLengthOfShip();
		
		StatRandomiser(MaxVariation, MinVariation);
		m_DangerDistance = m_core.MaxSpeed * 0.02f;
		
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
			//Debug.DrawLine(pos.position, pos.forward*400f, Color.white);
			if (Physics.Raycast(pos.position, transform.forward, Mathf.Infinity, WeaponsLayer) && m_TargetCore.Alive)
			{
				m_Weapon.FirePrimaryWeaponHold();
				break;
			}
		}
	}
	
	void MovementControl()
	{	
		//Debug.Log(m_Target.position);
		//Debug.Log(m_DangerDistance);
		//Debug.DrawLine(transform.position, Pointer.forward * 400f, Color.red);
		if (!m_InMotion)
		{
			/*
			if (!Physics.Linecast(transform.position + transform.forward * m_CastOffset, Focus.position, PathingLayer))
			{
				if (Vector3.Distance(Focus.position, transform.position) < m_DangerDistance)
				{
					SlowPursuit();
				}
				else 
				{
					Pursue();
				}
			}
			*/
			if (Physics.Raycast(transform.position + transform.forward * m_CastOffset, transform.forward, m_DangerDistance, PathingLayer))
			{
				EvasiveManoeuvers();
			}
			else
			{
				if (Vector3.Distance(Focus.position, transform.position) < m_DangerDistance)
				{
					SlowPursuit();
				}
				else 
				{
					Pursue();
				}
			}
		}
	}
	
	void Halt()
	{
		Debug.Log("Stopping");
		m_BattleMovement.HandBrake();
	}
	
	void TurnToTarget(Vector3 target)
	{
		Pointer.LookAt(target, Vector3.up);
		m_BattleMovement.TurnToward(Pointer.rotation);
	}
	// Could still have collisions here. Change to compare velocities. 
	void SlowPursuit()
	{
		Debug.Log("Slow pursuit");
		TurnToTarget(Focus.position);
		//if (m_core.Speed > m_TargetCore.Speed)
		//{
			m_BattleMovement.HandBrake();
		//}
	}
	
	void Pursue()
	{
		Debug.Log("In pursuit");
		TurnToTarget(Focus.position);
		m_BattleMovement.Accelerate();
	}
	
	void EvasiveManoeuvers()
	{
		Debug.Log("EvasiveManoeuvers");
		Vector3 horizontalDirection = ScannerSweep(SearchResolution, 1f, transform.right);
		Vector3 verticalDirection = ScannerSweep(SearchResolution, 1f, transform.forward);
		Vector3 direction = horizontalDirection + verticalDirection;
		StartCoroutine("MoveToPoint", direction);
	}
	
	// Multiplying a vector by a quaternion rotates the vector, so basically we're sweeping the area to find somewhere clear to turn to
	Vector3 ScannerSweep(float angle, float increment, Vector3 axis)
	{
		if (increment * angle > 360f)
		{
			//Debug.Log("No route");
			m_BattleMovement.HandBrake();
			return new Vector3(0,0,0); 
		}
		Quaternion p = Quaternion.Euler(axis * angle * increment);
		Vector3 rotatedVector = p * transform.position;
		if (!Physics.Raycast(transform.position, rotatedVector, m_DangerDistance, PathingLayer))
		{
			//Debug.Log(1);
			return rotatedVector;
		}
		else if (!Physics.Raycast(transform.position, rotatedVector*-1f , m_DangerDistance, PathingLayer))
		{
			//Debug.Log("-1");
			return rotatedVector*-1f;
		}
		else if (!Physics.Raycast(transform.position, transform.position + transform.forward, m_DangerDistance, PathingLayer))
		{
			//Debug.Log(0);
			return new Vector3(0,0,0);
		}
		else 
		{
			increment += 1f;
			return ScannerSweep(angle, increment, axis);
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
	
	public IEnumerator MoveToPoint(Vector3 direction)
	{
		m_InMotion = true;
		float i = FindPathFrequency;
		while (true)
		{
			i -= Time.fixedDeltaTime;
			if ( i < 0f )
			{
				m_InMotion = false;
				yield break;
			}
			TurnToTarget(direction * FindPathFrequency * m_core.MaxSpeed);
			m_BattleMovement.Accelerate();
			yield return null;
		}
	}
	
	public float GetLengthOfShip()
	{
		float max = 0;
		foreach (Collider col in m_CoreCollider)
		{
			float temp = Vector3.Magnitude(col.bounds.extents.z * transform.forward);
			if (temp > max)
			{
				max = temp;
			} 
		}
		return max;
	}
}
