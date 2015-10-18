using UnityEngine;
using System.Collections;

public class BattleMovement : MonoBehaviour 
{
	// How to use:
	//
	// Everything must be called from fixed update so that it's all synced up properly with the camera. This isn't such a big deal
	// For enemies cause the camera wont be on them but please try to keep things in fixed update regardless, say we want a mini
	// camera cutaway later, if it's not consistent with the updates it will jitter horribly and you'll only have to fix it then.
	//
	// m_Stats is the stats of the ships core, turn rate, max speed, whatever. m_body is the rigid body (obviously)
	// 
	// The gyroscope is a transform somewhere in the scene that just tells the ship what it's default rotation is, this is so that 
	// you can use the stabilise method.
	//
	// Roll magnitute and stabiliser active are variables that you set from a controller to start rolling/stabilising, you do this
	// rather than calling the methods directly so that they can be called within fixedupdate, which is important. So don't call 
	// those methods directly unless you want the movement to be jittery and awful. 
	private ShipCore m_Stats;
	private Rigidbody m_Body;
	[HideInInspector]private float m_Yaw = 0f;
	[HideInInspector]private float m_Pitch = 0f;
	public Transform Gyroscope;
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
		Movement();
		SnapToZero();
	}
	// We need to keep the gyroscope facing the right way all the time, dont want the stabiliser to move you left/right, just put you 
	// flat on the XZ plane.
	// TO DO: Optimise by making this call only when the stabiliser is called.
	void SetGyroscopeLevel()
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
	
	void SnapRotation()
	{	 
		SetGyroscopeLevel();
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Gyroscope.rotation, m_Stats.TurnRate * Time.fixedDeltaTime);
	}
	
	void Roll(float direction)
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
