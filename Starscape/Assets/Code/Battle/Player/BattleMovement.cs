using UnityEngine;
using System.Collections;

public class BattleMovement : MonoBehaviour 
{
	private ShipCore m_Stats;
	private Rigidbody m_Body;
	private float m_Speed;
	public GameObject Gyroscope;
	public float RightingRate = 1f;
	[HideInInspector] public float AltitudeChange = 0f;
	
	void Start()
	{	
		for (int i = 0; i<transform.childCount; i++)
		{	
			GameObject obj = transform.GetChild(i).gameObject;
			if (obj.tag == "Pointer")
			{
				Gyroscope = obj;
			}
		}
		m_Stats = GetComponent<ShipCore> ();
		m_Body = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate()
	{	
		MaintainGyroscopeLevel();
		ChangeAltitude(AltitudeChange);
		Movement();
		SnapToZero();
	}

	void MaintainGyroscopeLevel()
	{
		Gyroscope.transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
	}
	
	void Movement()
	{
		m_Body.AddRelativeForce(Vector3.forward * m_Speed * Time.fixedDeltaTime);
	}
	
	public void Accelerate()
	{
		if (m_Speed < m_Stats.MaxSpeed)
		{
			m_Speed += m_Stats.Acceleration*Time.deltaTime;
		}
	}
	
	public void ChangeAltitude(float direction)
	{
		m_Body.AddRelativeForce(Vector3.up * direction * m_Stats.AltitudeChangeRate * Time.fixedDeltaTime);
	}

	public void Decelerate()
	{
		if (m_Speed > -1f * m_Stats.MaxReverseSpeed)
		{
			m_Speed -= m_Stats.Deceleration*Time.deltaTime;
		}
	} 
	
	public void PitchYaw(float x, float y)
	{
		transform.Rotate( m_Stats.TurnRate * y * Time.deltaTime,m_Stats.TurnRate * x *Time.deltaTime, 0f );
	}
	
	public void SnapRotation()
	{	 
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Gyroscope.transform.rotation, RightingRate);
	}
	
	public void Roll(float direction)
	{
		transform.Rotate( 0f, 0f, Time.deltaTime * direction * m_Stats.RollRate );
	}
	
	void SnapToZero()
	{
		if(m_Speed < 0.03f * m_Stats.MaxSpeed & m_Speed > 0f)
		{
			m_Speed = Mathf.Lerp(m_Speed, 0f, Time.time);
		}
		else if (m_Speed > 0.03f * m_Stats.MaxReverseSpeed && m_Speed < 0f)
		{
			m_Speed = Mathf.Lerp(m_Speed, 0f, Time.time);
		}
	}
}
