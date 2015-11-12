using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDogfighter : MonoBehaviour 
{
	private float m_DangerDistance;
	public LayerMask PathingLayer;
	public Transform Focus;
	public Transform Pointer;
	private ShipCore m_core;
	private BattleMovement m_BattleMovement;
	public float MaxVariation = 1.5f;
	public float MinVariation = 0.7f;
	public float SearchResolution = 3f;
	public float FindPathFrequency = 10f;
	private bool m_InMotion;
	private Collider[] m_CoreCollider;
	private float m_CastOffset;
    public float Caution = 0.05f;
    private TargetingComputer m_TargetingComputer;

	void Start () 
	{
        m_TargetingComputer = gameObject.GetComponent<TargetingComputer>();
		m_core = gameObject.GetComponent<ShipCore>();
		m_BattleMovement = gameObject.GetComponent<BattleMovement>();
		
		m_CoreCollider = gameObject.GetComponentsInChildren<Collider>();
		m_CastOffset = GetLengthOfShip();
		
		StatRandomiser(MaxVariation, MinVariation);
		m_DangerDistance = m_core.MaxSpeed * Caution;
		
	}
	
	
	void FixedUpdate () 
	{
        if (Focus == null)
        {
            Halt();
            Focus = m_TargetingComputer.Focus;
        }
        else
        {
            MovementControl();
        }
	}
	
	void MovementControl()
	{	
		if (!m_InMotion)
		{
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
		//Debug.Log("Stopping");
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
		//Debug.Log("Slow pursuit");
		TurnToTarget(Focus.position);
		m_BattleMovement.HandBrake();
	}
	
	void Pursue()
	{
		//Debug.Log("In pursuit");
		TurnToTarget(Focus.position);
		m_BattleMovement.Accelerate();
	}
	
	void EvasiveManoeuvers()
	{
		//Debug.Log("EvasiveManoeuvers");
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
