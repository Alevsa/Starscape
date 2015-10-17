using UnityEngine;
using System.Collections;

public class BattleMovement : MonoBehaviour 
{
	private ShipCore m_Stats;
	private Rigidbody m_Body;
	[HideInInspector]private float m_Yaw = 0f;
	[HideInInspector]private float m_Pitch = 0f;
	public GameObject Gyroscope;
	public float RightingRate = 1f;
	[HideInInspector] public float RollMagnitude = 0f;
	[HideInInspector] public bool StabiliserActive;
	
	void Start()
	{	
		m_Stats = GetComponent<ShipCore> ();
		m_Body = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate()
	{	
		if (StabiliserActive)
			SnapRotation();
		MaintainGyroscopeLevel();
		Movement();
		SnapToZero();
	}

	void MaintainGyroscopeLevel()
	{
		Gyroscope.transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
	}
	
	void Movement()
	{
		Roll(RollMagnitude);
		transform.Rotate( m_Stats.TurnRate * m_Pitch * Time.fixedDeltaTime,m_Stats.TurnRate * m_Yaw *Time.fixedDeltaTime, 0f );
		m_Body.AddRelativeForce(Vector3.forward * m_Stats.Speed * Time.fixedDeltaTime);
	}
	
	public void Accelerate()
	{
		if (m_Stats.Speed < m_Stats.MaxSpeed)
		{
			m_Stats.Speed += m_Stats.Acceleration*Time.fixedDeltaTime;
		}
	}
	
	public void HandBrake()
	{
		if (m_Stats.Speed > 0f)
		{
			m_Stats.Speed -= m_Stats.Deceleration*Time.fixedDeltaTime;
		}
		else if (m_Stats.Speed < 0f)
		{
			m_Stats.Speed += m_Stats.Deceleration*Time.fixedDeltaTime;
		}
	}

	public void Decelerate()
	{
		if (m_Stats.Speed > -1f * m_Stats.MaxReverseSpeed)
		{
			m_Stats.Speed -= m_Stats.Deceleration*Time.fixedDeltaTime;
		}
	} 
	
	public void PitchYaw(float x, float y)
	{
		m_Yaw = x;
		m_Pitch = y;
	}
	
	public void SnapRotation()
	{	 
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Gyroscope.transform.rotation, RightingRate);
	}
	
	public void Roll(float direction)
	{
		transform.Rotate( 0f, 0f, Time.fixedDeltaTime * direction * m_Stats.RollRate );
	}
	
	void SnapToZero()
	{
		if(m_Stats.Speed < 0.03f * m_Stats.MaxSpeed & m_Stats.Speed > 0f)
		{
			m_Stats.Speed = Mathf.Lerp(m_Stats.Speed, 0f, Time.time);
		}
		else if (m_Stats.Speed > 0.03f * m_Stats.MaxReverseSpeed && m_Stats.Speed < 0f)
		{
			m_Stats.Speed = Mathf.Lerp(m_Stats.Speed, 0f, Time.time);
		}
	}
	
}
