using UnityEngine;
using System.Collections;

public class BattleMovement : MonoBehaviour 
{
	private ShipCore m_Stats;
	private Rigidbody m_Body;
	private float m_Speed;
	[HideInInspector]
	public Vector3 newPosition;
	
	void Start()
	{
		m_Stats = GetComponent<ShipCore> ();
		m_Body = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate()
	{
		movement();
	}
	
	void movement()
	{
		m_Body.AddRelativeForce(Vector3.forward * m_Speed);
	}
	
	public void Accelerate()
	{
		if (m_Speed < m_Stats.MaxSpeed)
		{
			m_Speed += m_Stats.Acceleration;
		}
	}
	
	public void Decelerate()
	{
		if (m_Speed > 0f)
		{
			m_Speed -= m_Stats.Deceleration;
		}
	} 
	/*
	public void roll(float direction)
	{
		transform.Rotate(new Vector3(0f, 0f, direction * stats.rollSensitivity ));
	}
	*/
	// Don't complain, it's a prototype.
	public void HandleMouse(float x, float y)
	{
		transform.Rotate(m_Stats.TurnRate * y, m_Stats.TurnRate * x, 0f);
	}
}
