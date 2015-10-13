using UnityEngine;
using System.Collections;

public class BattleMovement : MonoBehaviour 
{
	private ShipCore m_Stats;
	private Rigidbody m_Body;
	public float Speed {get; private set;}
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
		Movement();
		SnapToZero();
	}

	void MaintainGyroscopeLevel()
	{
		Gyroscope.transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
	}
	
	void Movement()
	{
		m_Body.AddRelativeForce(Vector3.forward * Speed * Time.fixedDeltaTime);
	}
	
	public void Accelerate()
	{
		if (Speed < m_Stats.MaxSpeed)
		{
			Speed += m_Stats.Acceleration*Time.deltaTime;
		}
	}
	
	public void HandBrake()
	{
		if (Speed > 0f)
		{
			Speed -= m_Stats.Deceleration*Time.deltaTime;
		}
		else if (Speed < 0f)
		{
			Speed += m_Stats.Deceleration*Time.deltaTime;
		}
	}

	public void Decelerate()
	{
		if (Speed > -1f * m_Stats.MaxReverseSpeed)
		{
			Speed -= m_Stats.Deceleration*Time.deltaTime;
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
		if(Speed < 0.03f * m_Stats.MaxSpeed & Speed > 0f)
		{
			Speed = Mathf.Lerp(Speed, 0f, Time.time);
		}
		else if (Speed > 0.03f * m_Stats.MaxReverseSpeed && Speed < 0f)
		{
			Speed = Mathf.Lerp(Speed, 0f, Time.time);
		}
	}
	
}
